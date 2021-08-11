<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HandleWithCare._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript"   >
        function AlertMessage(message) {
        alert(message)
    }
    </script>
    <div class="row">
        <div class="col-md-4">
            <h2>KPD Handle With Care
            </h2>
            <p>

                <asp:Table ID="Table1" runat="server" Height="67px" Width="680px" BackColor="White" BorderStyle="None" Font-Size="Medium" TabIndex="1">
                      <asp:TableRow>
                        <asp:TableCell style="padding: 2px 10px 2px 10px;">
                            Officer Email
                        </asp:TableCell>
                        <asp:TableCell style="padding: 2px 10px 2px 10px;">
                            Student Name 
                            </asp:TableCell> 
                        <asp:TableCell style="padding: 2px 10px 2px 10px;">
                            School Name
                         </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow >
                        <asp:TableCell  BorderStyle="None" style="padding: 2px 10px 2px 10px;" >
                            
                            <asp:TextBox ID="OfficerEmailTextBox" runat="server" TabIndex="1" Height="20px" Width="240px"></asp:TextBox>   
                            
                        </asp:TableCell>
                        <asp:TableCell  BorderStyle="None" style="padding: 2px 10px 2px 10px;">

                            <asp:TextBox ID="StudentNameTextBox" runat="server" TabIndex="2" Height="20px" Width="240px"></asp:TextBox>
                           
                            </asp:TableCell>
                        <asp:TableCell  BorderStyle="None" style="padding: 2px 10px 2px 10px;">
                            <asp:TextBox ID="SchoolNameTextBox" runat="server" TabIndex="3" Height="20px" Width="240px"></asp:TextBox>
                           
                         </asp:TableCell>
                     </asp:TableRow>
                    <asp:TableRow >
                        <asp:TableCell  BorderStyle="None" style="padding: 2px 10px 2px 10px;" >
                             
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="OfficerEmailTextBox" runat="server"  ForeColor="Red"  Display="Dynamic" ErrorMessage="Officer Email is Required"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                        <asp:TableCell  BorderStyle="None" style="padding: 2px 10px 2px 10px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2"  ControlToValidate="StudentNameTextBox" runat="server" ForeColor="Red"  Display="Dynamic" ErrorMessage="Student Name is Required"></asp:RequiredFieldValidator>
                            </asp:TableCell>
                        <asp:TableCell  BorderStyle="None" style="padding: 2px 10px 2px 10px;">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3"  ControlToValidate="SchoolNameTextBox"  runat="server" ForeColor="Red"  Display="Dynamic" ErrorMessage="School Name is Required"></asp:RequiredFieldValidator>
                         </asp:TableCell>
 
                    </asp:TableRow>

                </asp:Table>

            </p>
            <p>
                <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click"  Height="26px" Width="70px" />


            </p>
        </div>
        
    </div>

</asp:Content>
