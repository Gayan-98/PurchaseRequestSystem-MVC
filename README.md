# Purchase Request System 

This is a web application developed using .NET and following the Model-View-Controller (MVC) architecture. The application allows users to manage purchase requests, including creation, approval, and modification of purchase requests based on the user roles.

## Features

1. **Login Form**:
   - Username and Password authentication.
   
2. **Purchase Request Form**:
   - Generate unique purchase request numbers.
   - Input fields for Item Code, Item Quantity, and Item Cost.
   - Automatic calculation of Total Cost (Item Cost * Item Quantity).
   - Once a purchase request is saved, modification is not allowed unless disapproved.

3. **Purchase Request Approval Form** (Admin only):
   - Displays pending purchase requests in a table format.
   - Allows admins to approve or disapprove requests.
   - Requests can only be modified after disapproval.

4. **User Role Management**:
   - Admin users can access the Purchase Request Approval Form.
   - All users can inquire saved purchase requests.
   - Modification buttons are enabled only for disapproved requests.

## Installation Instructions

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/PurchaseRequestSystem-MVC.git
