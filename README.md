# ct_Inlogic_repo

## Prerequisites

Before running the project, make sure you have the following installed on your machine:

Angular: 15.0.2
.Net core: 8.0
SQL server: 2022
Node js: 18.20.4

## Setup Instructions

### 1. Clone the repository

Open your terminal or command prompt and execute the following command to clone the repository:
git clone https://github.com/brijraj-ct/ct_Inlogic_repo.git

### 2. Open Visual Studio

Launch Visual Studio.

Navigate to the cloned project directory.

Locate the appsettings.json file and change the connection string to match your SQL Server configuration.

Open Package Manager Console and select User_Registration_Demo.Infrastructure as Default Project

Run the following command in the Package Manager Console to create tables and seed default data in the database:
-> Update-Database

## Created Tables

### These are Identity tables created by Identity itself.

> > AspNetRoleClaims
> > AspNetRoles
> > AspNetUserClaims
> > AspNetUserLogins
> > AspNetUserRoles
> > AspNetUsers
> > AspNetUserTokens

### Tables created by us.

> > Coupons
> > SubscriptionFeatures
> > Subscriptions
> > UserSubscriptions

## Seeded Data

The following data will be seeded into the database:

### Subscription Table

PackageType: Monthly, PackageCost: 20.00, PackageDiscount: 0%
PackageType: Annual, PackageCost: 20.00, PackageDiscount: 20%

### SubscriptionFeatures Table

FeatureName: "Advance analytics"
FeatureName: "Mobile app access"
FeatureName: "Real-time updates and notifications"
FeatureName: "Up to 500 students"
FeatureName: "Multiple school branches"

### Coupons Table

CouponCode: "2024-JAN-1", DiscountPercentage: 10%
CouponCode: "2024-FEB-1", DiscountPercentage: 15%
CouponCode: "2024-MAR-1", DiscountPercentage: 20%
CouponCode: "2024-APR-1", DiscountPercentage: 25%
CouponCode: "2024-MAY-1", DiscountPercentage: 30%

### 3 Run your Backend

### 4 Open Visual Studio Code

Launch Visual Studio Code.

Open the angular folder within your cloned repository.

Open the integrated terminal in Visual Studio Code.

Run the following command to install all dependencies:
-> npm install --force

### 5 Run your Frontend

Run following command:
-> ng serve / npm start
