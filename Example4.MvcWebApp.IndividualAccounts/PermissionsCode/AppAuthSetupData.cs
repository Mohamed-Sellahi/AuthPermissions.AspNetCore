﻿// Copyright (c) 2021 Jon P Smith, GitHub: JonPSmith, web: http://www.thereformedprogrammer.net/
// Licensed under MIT license. See License.txt in the project root for license information.

using System.Collections.Generic;
using AuthPermissions.SetupCode;

namespace Example4.MvcWebApp.IndividualAccounts.PermissionsCode
{
    public static class AppAuthSetupData
    {
        public const string ListOfRolesWithPermissions = @"
SuperAdmin: AccessAll,
App Admin: UserRead, UserAdd, UserInfoChange, UserRolesChange, UserChangeTenant, UserRemove, RoleRead, RoleChange, TenantRead, TenantCreate, TenantUpdate

Tenant Admin: EmployeeRead, UserRead, UserAdd, UserInfoChange, RoleRead
Tenant Director: EmployeeRead
Area Manager: StockRead, SalesRead
Store Manager: StockRead, StockAddNew, StockRemove, SalesRead, SalesSell, SalesReturn
Sales Assistant: StockRead, SalesSell";

        public const string BulkHierarchicalTenants = @"
4U Inc.
4U Inc. | West Coast 
4U Inc. | West Coast | SanFran
4U Inc. | West Coast | SanFran | Dress4U
4U Inc. | West Coast | SanFran | Tie4U
4U Inc. | West Coast | LA 
4U Inc. | West Coast | LA | Shirt4U

4U Inc. | East Coast
4U Inc. | East Coast | NY Dress4U 
4U Inc. | East Coast | Boston Shirt4U

Pets2 Ltd.
Pets2 Ltd.|London|
Pets2 Ltd.|London|Cats Place
Pets2 Ltd.|London|Kitten Place";

        public static readonly List<DefineUserWithRolesTenant> UsersRolesDefinition = new List<DefineUserWithRolesTenant>
        {
            new DefineUserWithRolesTenant("Super@g1.com", null, "SuperAdmin"),
            new DefineUserWithRolesTenant("AppAdmin@g1.com", null, "App Admin"),
            //4U Inc.
            new DefineUserWithRolesTenant("admin@4uinc.com", null, 
                "Tenant Admin, Store Manager", tenantNameForDataKey: "4U Inc."),
            new DefineUserWithRolesTenant("director@4uinc.com", null,
                "Tenant Director, Area Manager", tenantNameForDataKey: "4U Inc."),
            new DefineUserWithRolesTenant("westCoastManager@4uinc.com", null,
                "Area Manager", tenantNameForDataKey: "4U Inc. | West Coast"),
            new DefineUserWithRolesTenant("eastCoastManager@4uinc.com", null,
                "Area Manager", tenantNameForDataKey: "4U Inc. | East Coast"),
            //Dress4U
            new DefineUserWithRolesTenant("Dress4UManager@4uinc.com", null,
                "Store Manager", tenantNameForDataKey: "4U Inc. | West Coast | SanFran | Dress4U"),
            new DefineUserWithRolesTenant("Dress4USales@4uinc.com", null,
                "Sales Assistant", tenantNameForDataKey: "4U Inc. | West Coast | SanFran | Dress4U"),
            //Tie4U
            new DefineUserWithRolesTenant("Tie4UManager@4uinc.com", null,
                "Store Manager", tenantNameForDataKey: "4U Inc. | West Coast | SanFran | Tie4U"),
            new DefineUserWithRolesTenant("Tie4USales@4uinc.com", null,
                "Sales Assistant", tenantNameForDataKey: "4U Inc. | West Coast | SanFran | Tie4U"),
            //Shirt4U
            new DefineUserWithRolesTenant("Shirt4UManager@4uinc.com", null,
                "Store Manager", tenantNameForDataKey: "4U Inc. | West Coast | SanFran | Shirt4U"),
            new DefineUserWithRolesTenant("Shirt4USales@4uinc.com", null,
                "Sales Assistant", tenantNameForDataKey: "4U Inc. | West Coast | SanFran | Shirt4U"),

            //Pets2 Ltd.
            new DefineUserWithRolesTenant("admin@pets2.com", null,
                "Tenant Admin, Store Manager", tenantNameForDataKey: "Pets2 Ltd."),
            new DefineUserWithRolesTenant("director@pets2.com", null,
                "Tenant Director, Area Manager", tenantNameForDataKey: "Pets2 Ltd."),
            //Dress4U
            new DefineUserWithRolesTenant("CatsManager@pets2.com", null,
                "Store Manager", tenantNameForDataKey: "Pets2 Ltd.|London|Cats Place"),
            new DefineUserWithRolesTenant("CatsSales@pets2.com", null,
                "Sales Assistant", tenantNameForDataKey: "Pets2 Ltd.|London|Cats Place"),
            //Tie4U
            new DefineUserWithRolesTenant("KittenManager@pets2.com", null,
                "Store Manager", tenantNameForDataKey: "Pets2 Ltd.|London|Kitten Place"),
            new DefineUserWithRolesTenant("KittenSales@pets2.com", null,
                "Sales Assistant", tenantNameForDataKey: "Pets2 Ltd.|London|Kitten Place"),


        };
    }
}