# 🐞 Bug Ticketing System

## Overview

The **Bug Ticketing System** is a .NET Web API application designed to help software teams efficiently manage bugs and issues in projects. With this system, Managers, Developers, and Testers can report, track, assign, and resolve bugs. The application supports authentication and autherization, user management, file attachments and password hashing for better security.

---

## 🧩 Key Concepts

### Users
- Three roles: **Manager**, **Developer**, **Tester**
- A user can have multiple roles and can be assigned to different bugs

### Projects
- Each project contains multiple bugs
- Each bug belongs to a single project

### Bugs
- Bugs can be assigned to multiple users
- Bugs can have multiple attachments (e.g., images, logs)

### Attachments
- Linked to specific bugs for more context or evidence

---

## 🛠️ Tech Stack

- **Framework:** ASP.NET Core Web API Using NTier Architecture
- **Authentication:** JWT (JSON Web Token)
- **Password Hashing:** BCrypt
- **Database:** Entity Framework Core (SQL Server)

---

## 🛠️ Future Plan

Modify it to work as a Full-Stack System with a website interface to help users to collaborate together through assigning bugs to projects and so on using MVC 

---

## 📚 API Endpoints

### 🔐 User Management

#### ➕ Register User
**POST** `/api/Users/register`  
Creates a new user account.

- **Body Parameters:**
  - `name`: User’s name
  - `email`: Email address
  - `password`: Secure password
  - `age`: User Age

---

#### 🔑 Login User
**POST** `/api/Users/login`  
Authenticates the user and returns an access token for authorized requests.

- **Body Parameters:**
  - `email`: Registered email
  - `password`: User’s password

---

#### 📄 Get All Users
**POST** `/api/Users`  
Retrieves a list of all Users.

---

#### 🔍 Get User Details By ID
**GET** `/api/User/:id`  
Fetches details of a specific User.

- **Path Parameter:**
  - `id`: User ID

---

#### 🔍 Update User Details By ID
**PUT** `/api/User/:id`  
Updates details of a specific User, but checks first if the user that updates is the same user that is logged.

- **Body Parameter:**
  - `id`: User’s ID
  - `name`: User’s name
  - `email`: Email address
  - `password`: Secure password
  - `age`: User Age

---

#### 🔍 Update User Details By ID (Manager)
**PUT** `/api/User/for-manager/:id`  
Updates details of a specific User, but checks first if the user has the manager role so he can update whatever he wants.

- **Body Parameter:**
  - `id`: User’s ID
  - `name`: User’s name
  - `email`: Email address
  - `age`: User Age
  - `role`: User Role (e.g., `["Developer", "Tester", "Manager"]`)

---

### 📁 Project Management

#### ➕ Create Project  
**POST** `/api/Projects`
Creates a new project.

- **Body Parameters:**
  - `name`: Project name
  - `status`: Project status (e.g., `["NotStarted", "InProgress", "Completed", "Cancelled"]`)

---

#### 📄 Get All Projects  
**GET** `/api/Projects`  
Retrieves a list of all projects.

---

#### 🔍 Get Project Details  
**GET** `/api/Projects/:id`  
Fetches details of a specific project, including its associated bugs.

- **Path Parameter:**
  - `id`: Project ID

---

### 🐛 Bug Management

#### ➕ Create Bug  
**POST** `/api/Bugs`  
Creates a new bug under a specific project.

- **Body Parameters:**
  - `name`: Bug title
  - `risk`: Risk Level (e.g., `["Low", "Normal", "Medium", "High", "Critical"]`)
  - `projectId`: ID of the project the bug belongs to

---

#### 📄 Get All Bugs  
**GET** `/api/Bugs`  
Lists all bugs in the system.

---

#### 🔍 Get Bug Details  
**GET** `/api/Bugs/:id`  
Retrieves detailed information about a specific bug.

- **Path Parameter:**
  - `id`: Bug ID

---

### 👥 User-Bug Relationships

#### ➕ Assign User to Bug  
**POST** `/api/Bugs/:id/assignees`  
Assigns a user to a specific bug.

- **Path Parameter:**
  - `id`: Bug ID  
- **Body Parameters:**
  - `userId`: ID of the user to assign

---

#### ➖ Remove User from Bug  
**DELETE** `/api/Bugs/:id/assignees/:userId`  
Removes a user from the list of assignees for a bug.

- **Path Parameters:**
  - `id`: Bug ID
  - `userId`: ID of the user to remove

---

#### 📄 Get All User Bugs  
**GET** `/api/UserBugs`  
Lists all user bugs in the system.

---

### 📎 File (Attachment) Management

#### 📤 Upload Attachment  
**POST** `/api/bugs/:id/attachments`  
Uploads an attachment (e.g., image or file) to a specific bug.

- **Path Parameter:**
  - `id`: Bug ID
- **Form Data:**
  - `file`: The file to upload

---

#### 📂 Get Attachments for Bug  
**GET** `/api/bugs/:id/attachments`  
Retrieves all uploaded attachments related to a specific bug.

- **Path Parameter:**
  - `id`: Bug ID

---

#### 🗑️ Delete Attachment  
**DELETE** `/api/bugs/:id/attachments/:attachmentId`  
Deletes a specific attachment from a bug.

- **Path Parameters:**
  - `id`: Bug ID
  - `attachmentId`: ID of the attachment to delete

---

# Thank you for reading!
