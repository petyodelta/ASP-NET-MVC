# Orders System
System for managing incoming new orders, outgoing orders and repair orders. 

## Build status
[![Build status](https://ci.appveyor.com/api/projects/status/yack5arp6i3yx16h?svg=true)](https://ci.appveyor.com/project/petyodelta/asp-net-mvc)

## Functionality
Registered users can have three roles admin, boss or worker. Admin can change, add or delete everything like incoming orders, outgoing orders, repair orders, add role to user, remove role from user or delete user. Boss can add or edit orders. Worker can be assigned to an order and can only change order status.
Public area(home page) where latest incoming orders can be seen.
Private area for users with role(boss, worker or admin).
Admin area for user with admin role. Here admin can make CRUD operations.
