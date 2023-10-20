# EF CLI

## BookStore Apps

- Add-Migration FirstInitDB -Project BookStore.Data -StartupProject BookStore.Admin 

- Update-Database -Project BookStore.Data -StartupProject BookStore.Admin


## Location Apps

- Add-Migration FirstInitDB -Project Locataion.Data -StartupProject Location.Api

- Update-Database -Project Locataion.Data -StartupProject Location.Api