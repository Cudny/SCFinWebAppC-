<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="InsertUpdateGridView.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvPhoneBook" runat="server" ShowFooter="true" DataKeyNames="PhoneBookID" ShowHeaderWhenEmpty="true"
                OnRowCommand="gvPhoneBook_RowCommand" OnRowEditing="gvPhoneBook_RowEditing" OnRowCancelingEdit="gvPhoneBook_RowCancelingEdit"
                OnRowUpdating="gvPhoneBook_RowUpdating"

                BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="false">
                <%-- Theme Prop --%>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

                <Columns>

                     <asp:TemplateField HeaderText="FirstName">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("FirstName") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate><!-- specify what gonna show if user click on edit button-->
                            <asp:TextBox ID="txtFirstName" Text='<%# Eval("FirstName") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox  ID="txtFirstNameFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="LastName">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("LastName") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate><!-- specify what gonna show if user click on edit button-->
                            <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox  ID="txtLastNameFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Contact">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Contact") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate><!-- specify what gonna show if user click on edit button-->
                            <asp:TextBox ID="txtContactName" Text='<%# Eval("Contact") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox  ID="txtContactNameFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Email">
                        <ItemTemplate>
                            <asp:Label Text='<%# Eval("Email") %>' runat="server" />
                        </ItemTemplate>
                        <EditItemTemplate><!-- specify what gonna show if user click on edit button-->
                            <asp:TextBox ID="txtEmailName" Text='<%# Eval("Email") %>' runat="server" />
                        </EditItemTemplate>
                        <FooterTemplate>
                            <asp:TextBox  ID="txtEmailNameFooter" runat="server" />
                        </FooterTemplate>
                    </asp:TemplateField>
                                       

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/002-edit.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Images/001-delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:ImageButton ImageUrl="~/Images/save.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                            <asp:ImageButton ImageUrl="~/Images/002-error.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                        
                        </EditItemTemplate>
                        <FooterTemplate>
                             <asp:ImageButton ImageUrl="~/Images/001-add-button.png" runat="server" CommandName="AddNew" ToolTip="AddNew" Width="20px" Height="20px" />
                         
                        </FooterTemplate>
                    </asp:TemplateField>
                   
                </Columns>

            </asp:GridView>
            <br />
            <asp:Label Text="" ID="lblSuccessMessage" runat="server" ForeColor="Green" />
            <br />
            <asp:Label Text="" ID="lblErrorMessage" runat="server" ForeColor="Red" />
          
        </div>
    </form>
</body>
</html>
