<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication4.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
      <script src="angular.js"></script>
        <script src="Data.js"></script>
   
    <title></title>
</head>
<body ng-app="app1">
    <h1>Smart 2.0</h1>
    <form id="form1" runat="server">
    <div ng-controller="DataCtrl">
        
    <table>
        <tr>
             <td>
                <b>PaymentTermID</b>
            </td>
             <td>
                <b>PaymentTermName</b>
            </td>
             <td>
                <b>NoOfDays</b>
            </td>
             <td>
                <b>Discount</b>
            </td>
            <td>
                <b>DiscountDays</b>
            </td>
            <td>
                <b>PaymentTermCode</b>
            </td>
        </tr>
      
      <tr ng-repeat="books in book">
           <td>
              <input type="text" id="pid{{books.PaymentTermId}}" value="{{books.PaymentTermId}}" /><br />
           </td>
          <td>
               <input type="text" value="{{books.PaymentTermName}}" /> <br />
           </td>
          <td>
               <input type="text" value="{{books.NoOfDays}}" /> <br />
           </td>
          <td>
               <input type="text" value="{{books.Discount}}" /> <br />
           </td>
          <td>
               <input type="text" value="{{books.DiscountDays}}" /> <br />
           </td>
          <td>
               <input type="text" value="{{books.PaymentTermCode}}" /> <br />
           </td>

        </tr>
      



    </table>
        
        
        <section >
        
        </section>
    
    </div>
         <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Height="50px" OnClick="Button1_Click"  ng-click="postdata(PaymentTermId, PaymentTermName, NoOfDays,Discount,DiscountDays,PaymentTermCode)" Text="Save" Width="95px" />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         
    </form>
    
</body>
</html>
