/*
to compile this source file, type
csc MyWinApp.cs
*/

using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.ComponentModel;

public class MyWinApp: Form {

Label label = new Label();
Button button = new Button();
TreeView tree = new TreeView();
ImageList imageList = new ImageList();
static String imageFolder = "Images" + Path.DirectorySeparatorChar.ToString();

// -------------- Images declarations ------------------------------------
Image newFileImage = new Bitmap(imageFolder + "newFile.bmp");
Image openFileImage = new Bitmap(imageFolder + "openFile.gif");
Image saveFileImage = new Bitmap(imageFolder + "saveFile.bmp");
Image printImage = new Bitmap(imageFolder + "print.gif");

// -------------- End of Images declaration------------------------------------

// -------------- menu ------------------------------------
MainMenu mainMenu = new MainMenu();

MenuItem fileMenuItem = new MenuItem();
MenuItem fileNewMenuItem;
MenuItem fileOpenMenuItem;
MenuItem fileSaveMenuItem;
MenuItem fileSaveAsMenuItem;
MenuItem fileMenuWithSubmenu;
MenuItem submenuMenuItem;
MenuItem fileExitMenuItem;

// -------------- End of menu ------------------------------------

// -------------- Toolbar ------------------------------------
ToolBar toolBar = new ToolBar();
ToolBarButton separatorToolBarButton = new ToolBarButton();
ToolBarButton newToolBarButton = new ToolBarButton();
ToolBarButton openToolBarButton = new ToolBarButton();
ToolBarButton saveToolBarButton = new ToolBarButton();
ToolBarButton printToolBarButton = new ToolBarButton();

// -------------- End of Toolbar ------------------------------------

// -------------- StatusBar ------------------------------------
StatusBar statusBar = new StatusBar();

StatusBarPanel statusBarPanel1 = new StatusBarPanel();
StatusBarPanel statusBarPanel2 = new StatusBarPanel();

// -------------- End of StatusBar ------------------------------------


public MyWinApp() {
InitializeComponent();
}

private void InitializeComponent() {
this.Text = "My Windows Application";
this.Icon = new Icon(imageFolder + "applicationLogo.ico");
this.Width = 400;
this.Height = 300;
this.StartPosition = FormStartPosition.CenterScreen;

imageList.Images.Add(newFileImage);
imageList.Images.Add(openFileImage);
imageList.Images.Add(saveFileImage);
imageList.Images.Add(printImage);


// menu
fileMenuItem.Text = "&File";

// the following constructor is the same as:
// menuItem fileNewMenuItem = new MenuItem();
// fileNewMenuItem.Text = "&New";
// fileNewMenuItem.Shortcut = Shortcut.CtrlN;
// fileNewMenuItem.Click += new
//System.EventHandler(this.fileNewMenuItem_Click);
fileNewMenuItem = new MenuItem("&New",new System.EventHandler(this.fileNewMenuItem_Click), Shortcut.CtrlN);

fileOpenMenuItem = new MenuItem("&Open",
new System.EventHandler(this.fileOpenMenuItem_Click), Shortcut.CtrlO);

fileSaveMenuItem = new MenuItem("&Save",
new System.EventHandler(this.fileSaveMenuItem_Click), Shortcut.CtrlS);

fileSaveAsMenuItem = new MenuItem("Save &As",
new System.EventHandler(this.fileSaveAsMenuItem_Click));

fileMenuWithSubmenu = new MenuItem("&With Submenu");

submenuMenuItem = new MenuItem("Su&bmenu",
new System.EventHandler(this.submenuMenuItem_Click));

fileExitMenuItem = new MenuItem("E&xit",
new System.EventHandler(this.fileExitMenuItem_Click));


mainMenu.MenuItems.Add(fileMenuItem);
fileOpenMenuItem.Checked = true;
fileMenuItem.MenuItems.Add(fileNewMenuItem);
fileMenuItem.MenuItems.Add(fileOpenMenuItem);
fileMenuItem.MenuItems.Add(fileSaveMenuItem);
fileMenuItem.MenuItems.Add(fileSaveAsMenuItem);
fileMenuItem.MenuItems.Add(fileMenuWithSubmenu);
fileMenuWithSubmenu.MenuItems.Add(submenuMenuItem);
fileMenuItem.MenuItems.Add("-"); // add a separator
fileMenuItem.MenuItems.Add(fileExitMenuItem);


toolBar.Appearance = ToolBarAppearance.Normal;
//toolBar.Appearance = ToolBarAppearance.Flat;
toolBar.ImageList = imageList;
toolBar.ButtonSize = new Size(14, 6);

separatorToolBarButton.Style = ToolBarButtonStyle.Separator;
newToolBarButton.ToolTipText = "New Document";
newToolBarButton.ImageIndex = 0;
openToolBarButton.ToolTipText = "Open Document";
openToolBarButton.ImageIndex = 1;
saveToolBarButton.ToolTipText = "Save";
saveToolBarButton.ImageIndex = 2;
printToolBarButton.ToolTipText = "Print";
printToolBarButton.ImageIndex = 3;

toolBar.ButtonClick += new

ToolBarButtonClickEventHandler(this.toolBar_ButtonClick);

toolBar.Buttons.Add(separatorToolBarButton);
toolBar.Buttons.Add(newToolBarButton);
toolBar.Buttons.Add(openToolBarButton);
toolBar.Buttons.Add(saveToolBarButton);
toolBar.Buttons.Add(separatorToolBarButton);
toolBar.Buttons.Add(printToolBarButton);

tree.Top = 40;
tree.Left = 20;
tree.Width = 100;
tree.Height = 100;

label.Location = new Point(220, 40);
label.Size = new Size(160, 30);
label.Text = "Yes, click the button";

button.Location = new Point(220, 80);
button.Size = new Size(100, 30);
button.Text = "Click this";
button.Click += new System.EventHandler(this.button_Click);

statusBarPanel1.BorderStyle = StatusBarPanelBorderStyle.Sunken;
statusBarPanel1.Text = "Press F1 for Help";
statusBarPanel1.AutoSize = StatusBarPanelAutoSize.Spring;
statusBarPanel2.BorderStyle = StatusBarPanelBorderStyle.Raised;
statusBarPanel2.ToolTipText = System.DateTime.Now.ToShortTimeString();
statusBarPanel2.Text = System.DateTime.Today.ToLongDateString();
statusBarPanel2.AutoSize = StatusBarPanelAutoSize.Contents;
statusBar.ShowPanels = true;
statusBar.Panels.Add(statusBarPanel1);
statusBar.Panels.Add(statusBarPanel2);


this.Menu = mainMenu;
this.Controls.Add(toolBar);
this.Controls.Add(tree);
this.Controls.Add(label);
this.Controls.Add(button);
this.Controls.Add(statusBar);
}


// -------------- Event Handlers --------------------------

private void fileNewMenuItem_Click(Object sender, EventArgs e) {
MessageBox.Show("You clicked the File -- New menu.", "The Event Information");
}

private void fileOpenMenuItem_Click(Object sender, EventArgs e) {
MessageBox.Show("You clicked the File -- Open menu.", "The Event Information");
}

private void fileSaveMenuItem_Click(Object sender, EventArgs e) {
MessageBox.Show("You clicked the File -- Save menu.", "The Event Information");
}

private void fileSaveAsMenuItem_Click(Object sender, EventArgs e) {
MessageBox.Show("You clicked the File -- Save As menu.", "The Event Information");
}

private void fileExitMenuItem_Click(Object sender, EventArgs e) {
MessageBox.Show("You clicked the File -- Exit As menu.", "The Event Information");
}
private void submenuMenuItem_Click(Object sender, EventArgs e) {
MessageBox.Show("You clicked the submenu.", "The Event Information");
}

protected void toolBar_ButtonClick(Object sender,

ToolBarButtonClickEventArgs e) {

// Evaluate the Button property to determine which button was clicked.
switch (toolBar.Buttons.IndexOf(e.Button)) {
case 1:
MessageBox.Show("Second button.", "The Event Information");
break;
case 2:
MessageBox.Show("third button", "The Event Information");
break;
case 3:
MessageBox.Show("fourth button.", "The Event Information");
break;
}
}
protected override void OnClosing(CancelEventArgs e) {
MessageBox.Show("Exit now.", "The Event Information");
}
private void button_Click(Object sender, System.EventArgs e) {
MessageBox.Show("Thank you.", "The Event Information");
}

// -------------- End of Event Handlers -------------------

public static void Main() {
MyWinApp form = new MyWinApp();
Application.Run(form);
} } 