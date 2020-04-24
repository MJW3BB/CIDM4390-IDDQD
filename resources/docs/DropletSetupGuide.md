# How to setup Ubuntu Server 18.04 with Nginx Reverse Proxy and ASP.NET Applications
## Matthew Webb
### Built With
- [Certbot](https://certbot.eff.org/) - Certificate Authourity
- [Digital Ocean](https://www.digitalocean.com/) - Cloud Computing Host
- [Ubuntu Server 18.04](https://ubuntu.com/download/server) - OS
- [NGINX](https://www.nginx.com/) - Load balancer, reverse proxy
- [Git Bash](https://gitforwindows.org/index.html) - for ssh and development
- [VS Code](https://code.visualstudio.com/) - development environment
- [Node.js](https://nodejs.org/en/) - Javascript Engine
### Information Sources
- [Initial Server Setup with Ubuntu 18.04](https://www.digitalocean.com/community/tutorials/initial-server-setup-with-ubuntu-18-04)
- [How To Install Linux, Nginx, MySQL, PHP (LEMP stack) on Ubuntu 18.04](https://www.digitalocean.com/community/tutorials/how-to-install-linux-nginx-mysql-php-lemp-stack-ubuntu-18-04)
- [Ubuntu 18.04 Package Manager - Install .NET Core](https://docs.microsoft.com/en-us/dotnet/core/install/linux-package-manager-ubuntu-1804)
- [Host ASP.NET Core on Linux with Nginx](https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-3.1)
- [How To Secure Nginx with Let's Encrypt on Ubuntu 18.04](https://www.digitalocean.com/community/tutorials/how-to-secure-nginx-with-let-s-encrypt-on-ubuntu-18-04)
### Follow the prompts to login via root and the console button on Digital Oceans site
### Change root password
- ssh into server after initial setup
```
ssh username@IP-ADDRESS
```
### Do this everytime you login to the server
```
sudo apt-get update && sudo apt-get install
```
### Add a user to the server (while logged in as root)
```
adduser username
```
Fill out all the prompts or leave them blank, press enter to continue

### Give user sudo privledges
```
usermod -aG sudo username
```
### Setup Firewall
```
ufw app list
ufw allow OpenSSH
ufw enable
yes
sudo ufw status // check status of firewall
```
### Install NGINX
```
sudo apt update
sudo apt install nginx
sudo ufw allow 'Nginx full'
```
### Install MySQL
```
sudo apt install mysql-server

sudo mysql_secure_installation
```
 - Select Option 2 (STRONG PASSWORD)
 - enter a strong password
 - press yes to all prompts

### Configure mySQL
```
SELECT user,authentication_string,plugin,host FROM mysql.user;

ALTER USER 'root'@'localhost' IDENTIFIED WITH mysql_native_password BY 'YOURDATABASEPASSWORD';
```
 - ENTER A STRONG PASSWORD (WRITE IT DOWN!)
```
SELECT user,authentication_string,plugin,host FROM mysql.user;

FLUSH PRIVLEDGES

exit

mysql -u root -p // to log back in
```
### Install PHP
```
sudo apt install php-fpm php-mysql
```

### Install .NET Core
```
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb

sudo dpkg -i packages-microsoft-prod.deb
```
### Install .Net Core SDK
```
sudo add-apt-repository universe
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-sdk-3.1
```

### Install the ASP.NET Core runtime
```
sudo add-apt-repository universe
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install aspnetcore-runtime-3.1
```
### Install the .NET Core runtime
```
sudo add-apt-repository universe
sudo apt-get update
sudo apt-get install apt-transport-https
sudo apt-get update
sudo apt-get install dotnet-runtime-3.1
```
### Create a configuration file for NGINX with the following information
- Navigate to etc/nginx/sites-available
```
sudo vim domainname.com
```
- Press I to INSERT
- Copy Paste the following
```
    server {
            # listen 80;
            # root /var/www/html;
            # index index.php index.html index.htm index.nginx-debian.html;
            server_name yourdomainname.com;

            location / {
                    # try_files $uri $uri/ =404;
                    proxy_pass http://localhost:5000;
                    proxy_http_version 1.1;
                    proxy_set_header Upgrade $http_upgrade;
                    proxy_set_header Connection keep-alive;
                    proxy_set_header Host $host;
                    proxy_cache_bypass $http_upgrade;
                    proxy_set_header X-Forwarded-For $proxy_add_x_forwarded_for;
                    proxy_set_header X-Forwarded-Proto $scheme;
            }

            location ~ \.php$ {
                    include snippets/fastcgi-php.conf;
                    fastcgi_pass unix:/var/run/php/php7.2-fpm.sock;
            }

            location ~ /\.ht {
                    deny all;
            }
    }
```
 - Press Esc
 - Type ':wq'
### Verify that your configuration file is correct
```
sudo nginx -t
```
If this fails, check your syntax and try again.
### Create a symbolic link between sites-available and sites-enabled
```
sudo ln -s /etc/nginx/sites-available/yourdomainname.com /etc/nginx/sites-enabled/
```
### Reload NGINX Service
```
sudo systemctl reload nginx
```
# WARNING: HERE THERE BE DRAGONS!
### You must have setup your domain name  setup to forward DNS requests to the droplets IP address

### Install Certbot
```
sudo add-apt-repository ppa:certbot/certbot
```
- Press ENTER
```
sudo apt install python-certbot-nginx
```
### Confirm NGINX Config (IMPORTANT)
```
sudo nginx -t
sudo systemctl reload nginx
```
### Obtain SSL Certificate with CertBot
```
sudo certbot --nginx -d yourdomainname.com -d www.yourdomainname.com
```
Select option '2' When asked about redirecting HTTP to HTTPS

You will be asked to enter your email address, this is required.

## Head back to your project on you local machine
### Add the following using statements in your startup class
```
using System.Net;
```
```
using Microsoft.AspNetCore.HttpOverrides;
```
### Copy paste this method in your startup class, just before the app.UseAuthentication(); method
```
    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
    });
```
### And do the same before the services.Configure<IdentityOptions> method with this
```
    services.Configure<ForwardedHeadersOptions>(options =>
    {
        options.KnownProxies.Add(IPAddress.Parse("127.0.0.1"));
    });
```    
### Head over to your properties\launchSettings.json file and make sure at the bottom it is configured to run on localhost:5000
```
    {
        "iisSettings": {
            "windowsAuthentication": false, 
            "anonymousAuthentication": true, 
            "iisExpress": {
            "applicationUrl": "http://localhost:22474",
            "sslPort": 44338
            }
        },
        "profiles": {
            "IIS Express": {
            "commandName": "IISExpress",
            "launchBrowser": true,
            "environmentVariables": {
                "ASPNETCORE_ENVIRONMENT": "Development"
            }
            },
            "ProjectName": {
            "commandName": "Project",
            "launchBrowser": true,
            "applicationUrl": "http://localhost:5000",
            "environmentVariables": {
                "ASPNETCORE_ENVIRONMENT": "Development"
            }
            }
        }
    }
```
### Push to git
- Stage, committ, and push all your changes to your code repository
### Init a git on the server
- Head back to the server in your ssh session
- Navigate to home/username
```
sudo mkdir projects
cd projects
sudo mkdir projectname
cd projectname
git init
git remote add origin https://githubrepoURL.git
```
### Pull down from git repository
```
git pull origin BRANCHNAME
```
### Publish
- One the changes are complete, run this command
```
dotnet publish --configuration Release
```
- Release will be the name of the folder or your publication, call it whatever you want
- The project files will get placed in 'bin\Release\netcoreapp3.1\publish'
### Establish a symbolic link between your published folder and the live version (var/www)
```
sudo ln -s ~/projects/PROJECTNAME/bin/Release/netcoreapp3.1/publish/ PROJECTNAME
```
- If the folder PROJECTNAME does not yet exist create it
### Create a service to run and monitor your application
```
sudo vim /etc/systemd/system/nameofyourservice.service
```
- copy and paste the info and modify it for your application name
```
    [Unit]
    Description=ASP.NET App

    [Service]
    WorkingDirectory=/var/www/projectname-live
    ExecStart=/usr/bin/dotnet /var/www/projectname-live/project.dll
    Restart=always
    # Restart service after 10 seconds if the dotnet service crashes:
    RestartSec=10
    KillSignal=SIGINT
    SyslogIdentifier=dotnet-example
    User=username
    Environment=ASPNETCORE_ENVIRONMENT=Production
    Environment=DOTNET_PRINT_TELEMETRY_MESSAGE=false

    [Install]
    WantedBy=multi-user.target
```
### Enable your service
```
    sudo systemctl enable nameofyourservice.service
```
### Start your service
```
    sudo systemctl start nameofyourservice.service
```
### Check status of your service
```
    sudo systemctl status nameofyourservice.service
```
### Yields
```
    ● kestrel-helloapp.service - Example .NET Web API App running on Ubuntu
        Loaded: loaded (/etc/systemd/system/kestrel-helloapp.service; enabled)
        Active: active (running) since Thu 2016-10-18 04:09:35 NZDT; 35s ago
    Main PID: 9021 (dotnet)
        CGroup: /system.slice/kestrel-helloapp.service
                └─9021 /usr/local/bin/dotnet /var/www/helloapp/helloapp.dll
```
### Stop your service
```
    sudo systemctl stop nameofyourservice.service
```
### Disable your service
```
sudo systemctl disable nameofyourservice.service
```
# Congradulations! Your Done!
![Take A Break](https://68.media.tumblr.com/d4fde8073f44afd9717868e3fe126013/tumblr_ohzkx6FZ0B1u5vp7wo1_500.gif)

## Updating the Website to reflect changes to the webapp
1. Stop the service 
```
sudo systemctl stop nameofyourservice.service
```
2. Pull your changes
```
git pull origin BRANCHNAME
```
3. Publish a new build
```
dotnet publish --configuration Release
```
4. Start your service again
```
sudo systemctl start nameofyourservice.service
```







