;#DropDB McTicaretEasyTest

#Application McTicaret.Win
#Application McTicaret.Web

*FillForm
 User Name = Admin
*Action Log In

#IfDef McTicaret.Win

*Action About...
 
*Action OK

#EndIf

#IfDef McTicaret.Web
*Action Navigation(My Details)
#EndIf
