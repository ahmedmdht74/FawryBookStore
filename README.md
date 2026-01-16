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

<table>
  <tr>
    <!-- أول جدول -->
    <td>
      <table border="1" cellpadding="4" cellspacing="0">
        <tr><th colspan="5">AspNetUsers 1</th></tr>
        <tr><td>Id</td><td>UserName</td><td>NormalizedUserName</td><td>Email</td><td>NormalizedEmail</td></tr>
        <tr><td>EmailConfirmed</td><td>PasswordHash</td><td>SecurityStamp</td><td>ConcurrencyStamp</td><td>PhoneNumber</td></tr>
        <tr><td>PhoneNumberConfirmed</td><td>TwoFactorEnabled</td><td>LockoutEnd</td><td>LockoutEnabled</td><td>AccessFailedCount</td></tr>
        <tr><td>FirstName</td><td>LastName</td><td>Image</td><td>CreatedDate</td><td>IsActive</td></tr>
      </table>
    </td>

    <!-- ثاني جدول جنب الأول -->
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

