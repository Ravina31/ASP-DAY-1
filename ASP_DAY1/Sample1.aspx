<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sample1.aspx.cs" Inherits="Sample1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <h1> Registration Form</h1>
    <script>
        function f1(sender, e)
        {
            if (e.Value.length != 10)
                e.IsValid = false;
        }
    </script>
   
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table align="center">
       
            <tr>
            <td>Username</td>
           <%-- <td> <input type="text" id="txtuser" name="txtuser"  runat="server"/> </td>--%>
                <td> <asp:TextBox runat="server" ID="txtuser"></asp:TextBox>  </td>
                <td><asp:RequiredFieldValidator runat="server" Text="*" Forecolor="red" ControlToValidate="txtuser" ErrorMessage="Please enter username" ValidationGroup="insert"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
            <td>Password</td>
            <%--<td> <input type="password" id="txtpwd" name="txtpwd" runat="server" /> </td>--%>
                <td><asp:TextBox runat="server" ID="txtpwd" TextMode="Password"></asp:TextBox></td>
                 <td><asp:RequiredFieldValidator runat="server" Text="*" Forecolor="red" ControlToValidate="txtpwd" ErrorMessage="Please enter password" ValidationGroup="insert"></asp:RequiredFieldValidator></td>

            </tr>
        <tr>
            <td>Confirm password</td>
           <%-- <td> <input type="password" id="conpwd" name="conpwd" runat="server"/> </td>--%>
             <td><asp:TextBox runat="server" ID="conpwd" TextMode="Password"></asp:TextBox></td>
             <td><asp:RequiredFieldValidator runat="server" Text="*" Forecolor="red" ControlToValidate="conpwd" Display="Dynamic" ErrorMessage="Please enter password again" ValidationGroup="insert"></asp:RequiredFieldValidator>
            <asp:CompareValidator runat="server" ControlToValidate="conpwd" Text="*" Forecolor="red" Display="Dynamic" ControlToCompare="txtpwd" ErrorMessage="password mismatch" ValidationGroup="insert"></asp:CompareValidator></td>
            </tr>
        
             <tr>
            <td>Email</td>
           <%-- <td> <input type="text" id="email" name="email" runat="server" /> </td>--%>
                  <td> <asp:TextBox runat="server" ID="email"></asp:TextBox>  </td>
                 <td> <asp:RegularExpressionValidator runat="server" Text="*" Forecolor="red" ControlToValidate="email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Please enter valid email" ValidationGroup="insert"></asp:RegularExpressionValidator></td>
                 
            </tr>
        <tr>
         
            <td>Age</td>
           <%-- <td> <input type="text" id="age" name="age" runat="server" /> </td>--%>
         <td> <asp:TextBox runat="server" ID="age"></asp:TextBox>  </td>
            <td><asp:RequiredFieldValidator runat="server" ControlToValidate="age" Text="*" Forecolor="red" ErrorMessage="Please enter age" ValidationGroup="insert"></asp:RequiredFieldValidator></td>
        <td> <asp:RangeValidator runat="server" ControlToValidate="age" MaximumValue="60"  MinimumValue="18" ErrorMessage="Please enter the age between 18 and 60"></asp:RangeValidator></td>    
        </tr>
         <tr>
            <td>Mobile</td>
           <%-- <td> <input type="text" id="mobile" name="mobile"  runat="server"/> </td>--%>
              <td> <asp:TextBox runat="server" ID="mobile"></asp:TextBox>  </td>
              <td><asp:RequiredFieldValidator runat="server" ControlToValidate="mobile"  Text="*" Forecolor="red" ErrorMessage="Please enter age" ValidationGroup="insert"></asp:RequiredFieldValidator>
                  <asp:CustomValidator ClientValidationFunction="f1" ControlToValidate="mobile" ErrorMessage="Length error"  runat="server" OnServerValidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
              </td>
            
         </tr>
         <tr>
             <td>Country</td>
             <td><asp:DropDownList runat="server" ID="country" >
                  <%--<asp:ListItem Text="Select Country" Value="Select Country"> </asp:ListItem>
                 <asp:ListItem Text="India" Value="india"> </asp:ListItem>
                 <asp:ListItem Text="US" Value="us"> </asp:ListItem>
                 <asp:ListItem Text="Canada" Value="canada"> </asp:ListItem>--%>
               
                 </asp:DropDownList> </td>
             <td><asp:RequiredFieldValidator runat="server" ControlToValidate="country" Text="*" Forecolor="red" InitialValue="Select Country" ErrorMessage="Select Country" ValidationGroup="insert"></asp:RequiredFieldValidator></td>
             </tr>

                <td>
       <%-- <input type="submit" value="submit" runat="server"/>--%>
                    <asp:Button ID="btnsubmit" runat="server" Text="submit" OnClick="btnsubmit_Click" Height="26px" Width="64px" ValidationGroup="insert" />
                </td>
        
              <td>
        <%--<input type="reset" value="reset" runat="server" />--%>
                   <asp:Button ID="btnreset" runat="server" Text="reset" Width="55px" ValidationGroup="insert" />
               </td>
         </tr>
       </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AutoGenerateDeleteButton="True" AutoGenerateEditButton="True" Height="220px" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing"  Width="295px" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="NAME" ReadOnly="True" />
                <asp:BoundField DataField="password" HeaderText="PASSWORD" />
                <asp:BoundField DataField="email" HeaderText="EMAIL" />
                <asp:BoundField DataField="age" HeaderText="AGE" />
                <asp:BoundField DataField="mobile" HeaderText="PHONE NO" />
                <asp:BoundField DataField="country" HeaderText="COUNTRY" />
            </Columns>
        </asp:GridView>
        <asp:ValidationSummary runat="server" Forecolor="red"/>
        <asp:Label ID="lblheader" runat="server"></asp:Label>
    </form>
</body>
</html>
