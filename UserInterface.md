# CIDM-4390: 2020SP SOFTWARE SYS DEVEL

## Installing a template into a program

1. Select the template that is to be used and download into the program.

2. Choose the files:
    * css
    * fonts
    * img
    * js
    * lib
    * scss
    * favicon.ico (a folder that is used for icons on the "URL" web address bar)

3. Copy all these files into the wwwroot folder, (these will replace the files in the wwwroot folder).

4. In the Pages/Shared/_Layout.cshtml file contains the basic layout of the website and all the pages. Finding which pieces that need to be consistent, (the navbar and the footer), will be the primary use within this file.

5. The Index page contains the "home" page look and interface. This will contain the _Layout.cshtml file for the navbar and footer. Add additional information/links/references/images wanted needed.

6. Use the scripts called for on every page of the program to implement the header, body, and footer. The header will call in every reference to the stylesheet needed for the template.  The body contains the look of the web page. The footer contains the information on the bottom of the page. 
    * The Template used on this project was: (https://templatemo.com/tm-538-digital-trend). 
    * It allows the usage of multiple pages within the project. 
    
7. Running the project will allow details to be corrected.