<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WebApplication4.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table class="table table-striped table-bordered">  
 <thead>  
  <th>Employee Name</th>  
  <th>Employee Email</th>  
  <th>Employee Salary</th>  
  <th>Active</th>  
  <th>Edit</th>  
 </thead>  
 <tbody>  
  <tr ng-repeat="employee in employees" ng-include="getTemplate(employee)">  
   <script type="text/ng-template" id="display">  
    <td>{{employee.empName}}</td>  
    <td>{{employee.empEmail}}</td>  
    <td>{{employee.empSalary | currency:"₹"}}</td>  
    <td>{{employee.active | active}}</td>  
    <td>  
     <button type="button" class="btn btn-primary" ng-click="editEmployee(employee)">Edit</button>  
     <button type="button" class="btn btn-danger" ng-click="deleteEmployee(employee)">Delete</button>  
    </td>  
   </script>  
   <script type="text/ng-template" id="edit">  
    <td><input type="text" ng-model=employee.empName class="form-control input-sm"/></td>  
    <td><input type="text" ng-model=employee.empEmail class="form-control input-sm"/></td>  
    <td><input type="text" ng-model=employee.empSalary class="form-control input-sm"/></td>  
    <td>  
      <select class="form-control input-sm" ng-model=employee.active>  
        <option value='1'>Yes</option>  
        <option value='0'>No</option>  
      </select>  
    </td>  
    <td>  
     <button type="button" class="btn btn-primary" ng-click="updateEmployee(employee)">Save</button>  
     <button type="button" class="btn btn-danger" ng-click="reset()">Cancel</button>  
    </td>  
   </script>  
  </tr>  
 </tbody>  
<table>
    </div>
    </form>
</body>
</html>
