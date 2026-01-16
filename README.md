# 📚 BookStore Console App

A simple console-based BookStore application built with **C#**, **LINQ**, and **SQL Server**.  
Users can manage and buy books based on their type (shipped, emailed, or read-only).

## ✅ Features

1. Show all books  
2. Add a new book  
3. List outdated books  
4. Show deleted outdated books  
5. Buy a book based on its type:
   - 📦 Shipping via address  
   - 📧 Sending via email  
   - 📖 Read-only (not for sale)

## 🛠 Tech Stack

- C# (.NET Core)
- LINQ
- SQL Server

## ▶️ Run It

1. Clone the repository  
2. Update the DB connection string if needed  
3. Run the app


---
<!-- ====== صف الجداول الكبيرة ====== -->
<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="5">AspNetUsers 1</th></tr>
        <tr><td>Id</td><td>UserName</td><td>NormalizedUserName</td><td>Email</td><td>NormalizedEmail</td></tr>
        <tr><td>EmailConfirmed</td><td>PasswordHash</td><td>SecurityStamp</td><td>ConcurrencyStamp</td><td>PhoneNumber</td></tr>
        <tr><td>PhoneNumberConfirmed</td><td>TwoFactorEnabled</td><td>LockoutEnd</td><td>LockoutEnabled</td><td>AccessFailedCount</td></tr>
        <tr><td>FirstName</td><td>LastName</td><td>Image</td><td>CreatedDate</td><td>IsActive</td></tr>
      </table>
    </td>
  </tr>
</table>

<!-- ====== صف الجداول الكبيرة ====== -->
<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="5">BodyProfile 1</th></tr>
        <tr><td>Id</td><td>UserId</td><td>Gender</td><td>Height</td><td>Weight</td></tr>
        <tr><td>BodyShape</td><td>SkinTone</td><td>HairColor</td><td>EyeColor</td><td>PreferredStyle</td></tr>
        <tr><td>AvatarUrl</td><td></td><td></td><td></td><td></td></tr>
      </table>
    </td>
  </tr>
</table>

<!-- ====== صف الجداول الكبيرة ====== -->
<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="5">Category 1</th></tr>
        <tr><td>Id</td><td>Name</td><td>Gender</td><td></td><td></td></tr>
      </table>
    </td>
  </tr>
</table>

<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="5">SubCategory 1</th></tr>
        <tr><td>Id</td><td>CategoryId</td><td>Name</td><td></td><td></td></tr>
      </table>
    </td>
  </tr>
</table>

<!-- ====== صف الجداول الكبيرة ====== -->
<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="5">Product 1</th></tr>
        <tr><td>Id</td><td>Name</td><td>CategoryId</td><td>Description</td><td></td></tr>
      </table>
    </td>
  </tr>
</table>

<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="5">ProductVariant 1</th></tr>
        <tr><td>Id</td><td>ProductId</td><td>Size</td><td>Color</td><td>Price</td></tr>
        <tr><td>Stock</td><td>Model3DUrl</td><td></td><td></td><td></td></tr>
      </table>
    </td>
  </tr>
</table>

<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="5">VariantImage 1</th></tr>
        <tr><td>Id</td><td>VariantId</td><td>ImageUrl</td><td></td><td></td></tr>
      </table>
    </td>
  </tr>
</table>

<!-- ====== صف الجداول الكبيرة ====== -->
<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="5">Cart 1</th></tr>
        <tr><td>Id</td><td>UserId</td><td>CreatedAt</td><td>IsDeleted</td><td>TotalPrice</td></tr>
      </table>
    </td>
  </tr>
</table>

<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="5">CartItem 1</th></tr>
        <tr><td>Id</td><td>CartId</td><td>VariantId</td><td>Quantity</td><td></td></tr>
      </table>
    </td>
  </tr>
</table>

<!-- ====== صف الجداول الصغيرة جنب بعض ====== -->
<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="3">AspNetRoles 1</th></tr>
        <tr><td>Id</td><td>Name</td><td>NormalizedName</td></tr>
        <tr><td>ConcurrencyStamp</td><td></td><td></td></tr>
      </table>
    </td>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="2">AspNetUserRoles 1</th></tr>
        <tr><td>UserId</td><td>RoleId</td></tr>
      </table>
    </td>
  </tr>
</table>

<!-- ====== صف الجداول الصغيرة جنب بعض ====== -->
<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="3">State 1</th></tr>
        <tr><td>Id</td><td>Name</td><td></td></tr>
      </table>
    </td>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="3">City 1</th></tr>
        <tr><td>Id</td><td>Name</td><td>StateId</td></tr>
      </table>
    </td>
  </tr>
</table>

<!-- ====== صف الجداول الكبيرة ====== -->
<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="5">Favorite 1</th></tr>
        <tr><td>UserId</td><td>VariantId</td><td>CreatedAt</td><td></td><td></td></tr>
      </table>
    </td>
  </tr>
</table>

<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="6">Order 1</th></tr>
        <tr><td>Id</td><td>UserId</td><td>CreatedDate</td><td>Status</td><td>TotalPrice</td><td>Address</td></tr>
      </table>
    </td>
  </tr>
</table>

<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="5">OrderItem 1</th></tr>
        <tr><td>Id</td><td>OrderId</td><td>VariantId</td><td>Quantity</td><td></td></tr>
      </table>
    </td>
  </tr>
</table>

<table>
  <tr>
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="6">Contact 1</th></tr>
        <tr><td>Id</td><td>UserId</td><td>Subject</td><td>Message</td><td>CreatedDate</td><td>Status</td></tr>
      </table>
    </td>
  </tr>
</table>

