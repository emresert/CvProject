[1mdiff --git a/.vs/Cv/v14/.suo b/.vs/Cv/v14/.suo[m
[1mindex a2133f1..3b89681 100644[m
Binary files a/.vs/Cv/v14/.suo and b/.vs/Cv/v14/.suo differ
[1mdiff --git a/Cv/Controllers/UserinfoController.cs b/Cv/Controllers/UserinfoController.cs[m
[1mindex 3e6bc34..e64e0ef 100644[m
[1m--- a/Cv/Controllers/UserinfoController.cs[m
[1m+++ b/Cv/Controllers/UserinfoController.cs[m
[36m@@ -12,7 +12,13 @@[m [mnamespace Cv.Controllers[m
     public class UserinfoController : Controller[m
     {[m
         private CvEntities db = new CvEntities();[m
[32m+[m[32m        public ActionResult UserToDoList()[m
[32m+[m[32m        {[m
[32m+[m
 [m
[32m+[m[32m            return View();[m
[32m+[m[32m        }[m
[32m+[m[41m       [m
         [m
         public ActionResult Show()[m
         {// find 1 den fazla yani liste şeklinde firsordefault ise sadece  1 kayıt döndürür[m
[36m@@ -73,11 +79,11 @@[m [mnamespace Cv.Controllers[m
                     db.tbl_Userinfo.Add(userinfo);[m
                     db.SaveChanges();[m
                     ViewBag.den = "Kayıt et";[m
[31m-                    return RedirectToAction("Show",userinfo);[m
[32m+[m[32m                    return RedirectToAction("Show");[m
                 } else {[m
 [m
[31m-                    ViewBag.den = "dsadsad";[m
[31m-                    return RedirectToAction("Contact","Home");[m
[32m+[m[32m                    ViewBag.den = "Zaten bir kaydınız var.";[m
[32m+[m[32m                    return RedirectToAction("UserToDoList");[m
                 }[m
                     [m
                 }[m
[36m@@ -115,7 +121,24 @@[m [mnamespace Cv.Controllers[m
             db.SaveChanges();[m
             return RedirectToAction("Show");[m
         }[m
[32m+[m[32m        public ActionResult Delete()[m
[32m+[m[32m        {[m
[32m+[m[32m            var dataSet = Session["Users"] as tbl_Member;[m
[32m+[m[32m            var member = db.tbl_Userinfo.FirstOrDefault(m => m.fk_UserID == dataSet.UserID);[m
[32m+[m[32m            var change = new UserinfoModel();[m
[32m+[m[32m            change.UserInfoID = member.UserInfoID;[m
[32m+[m[32m            change.Adress = member.Adress;[m
[32m+[m[32m            change.DateOfBirth = member.DateOfBirth;[m
[32m+[m[32m            change.PhoneNumber = member.PhoneNumber;[m
[32m+[m[32m            change.UserImage = member.UserImage;[m
[32m+[m[32m            change.fk_UserID = member.fk_UserID;[m
[32m+[m[32m            db.tbl_Userinfo.Remove(member);[m
[32m+[m[32m            db.SaveChanges();[m
[32m+[m[32m            return View("UserToDoList");[m
[32m+[m[32m        }[m
[32m+[m
 [m
 [m
     }[m
[32m+[m
 }[m
\ No newline at end of file[m
[1mdiff --git a/Cv/Cv.csproj b/Cv/Cv.csproj[m
[1mindex 570e93d..a407f59 100644[m
[1m--- a/Cv/Cv.csproj[m
[1m+++ b/Cv/Cv.csproj[m
[36m@@ -334,6 +334,8 @@[m
     <Content Include="Views\Userinfo\Create.cshtml" />[m
     <Content Include="Views\Userinfo\Show.cshtml" />[m
     <Content Include="Views\Userinfo\Edit.cshtml" />[m
[32m+[m[32m    <Content Include="Views\Userinfo\Delete.cshtml" />[m
[32m+[m[32m    <Content Include="Views\Userinfo\UserToDoList.cshtml" />[m
   </ItemGroup>[m
   <ItemGroup>[m
     <Folder Include="App_Data\" />[m
[1mdiff --git a/Cv/Views/Userinfo/Delete.cshtml b/Cv/Views/Userinfo/Delete.cshtml[m
[1mnew file mode 100644[m
[1mindex 0000000..460443d[m
[1m--- /dev/null[m
[1m+++ b/Cv/Views/Userinfo/Delete.cshtml[m
[36m@@ -0,0 +1,73 @@[m
[32m+[m[32m﻿@model Cv.Models.UserinfoModel[m
[32m+[m
[32m+[m[32m@{[m
[32m+[m[32m    ViewBag.Title = "Delete";[m
[32m+[m[32m    Layout = "~/Views/Shared/_Layout.cshtml";[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32m<h2>Delete</h2>[m
[32m+[m
[32m+[m[32m<h3>Are you sure you want to delete this?</h3>[m
[32m+[m[32m<div>[m
[32m+[m[32m    <h4>tbl_Userinfo</h4>[m
[32m+[m[32m    <hr />[m
[32m+[m[32m    <dl class="dl-horizontal">[m
[32m+[m[32m        <dt>[m
[32m+[m[32m            @Html.DisplayNameFor(model => model.DateOfBirth)[m
[32m+[m[32m        </dt>[m
[32m+[m
[32m+[m[32m        <dd>[m
[32m+[m[32m            @Html.DisplayFor(model => model.DateOfBirth)[m
[32m+[m[32m        </dd>[m
[32m+[m
[32m+[m[32m        <dt>[m
[32m+[m[32m            @Html.DisplayNameFor(model => model.PhoneNumber)[m
[32m+[m[32m        </dt>[m
[32m+[m
[32m+[m[32m        <dd>[m
[32m+[m[32m            @Html.DisplayFor(model => model.PhoneNumber)[m
[32m+[m[32m        </dd>[m
[32m+[m
[32m+[m[32m        <dt>[m
[32m+[m[32m            @Html.DisplayNameFor(model => model.Adress)[m
[32m+[m[32m        </dt>[m
[32m+[m
[32m+[m[32m        <dd>[m
[32m+[m[32m            @Html.DisplayFor(model => model.Adress)[m
[32m+[m[32m        </dd>[m
[32m+[m
[32m+[m[32m        <dt>[m
[32m+[m[32m            @Html.DisplayNameFor(model => model.UserImage)[m
[32m+[m[32m        </dt>[m
[32m+[m
[32m+[m[32m        <dd>[m
[32m+[m[32m            @Html.DisplayFor(model => model.UserImage)[m
[32m+[m[32m        </dd>[m
[32m+[m
[32m+[m[32m        <dt>[m
[32m+[m[32m            @Html.DisplayNameFor(model => model.tbl_Gender.Gender)[m
[32m+[m[32m        </dt>[m
[32m+[m
[32m+[m[32m        <dd>[m
[32m+[m[32m            @Html.DisplayFor(model => model.tbl_Gender.Gender)[m
[32m+[m[32m        </dd>[m
[32m+[m
[32m+[m[32m        <dt>[m
[32m+[m[32m            @Html.DisplayNameFor(model => model.tbl_Member.UserName)[m
[32m+[m[32m        </dt>[m
[32m+[m
[32m+[m[32m        <dd>[m
[32m+[m[32m            @Html.DisplayFor(model => model.tbl_Member.UserName)[m
[32m+[m[32m        </dd>[m
[32m+[m
[32m+[m[32m    </dl>[m
[32m+[m
[32m+[m[32m    @using (Html.BeginForm()) {[m
[32m+[m[32m        @Html.AntiForgeryToken()[m
[32m+[m
[32m+[m[32m        <div class="form-actions no-color">[m
[32m+[m[32m            <input type="submit" value="Delete" class="btn btn-default" /> |[m
[32m+[m[32m            @Html.ActionLink("Back to List", "Index")[m
[32m+[m[32m        </div>[m
[32m+[m[32m    }[m
[32m+[m[32m</div>[m
[1mdiff --git a/Cv/Views/Userinfo/Show.cshtml b/Cv/Views/Userinfo/Show.cshtml[m
[1mindex 0d50062..033e287 100644[m
[1m--- a/Cv/Views/Userinfo/Show.cshtml[m
[1m+++ b/Cv/Views/Userinfo/Show.cshtml[m
[36m@@ -59,7 +59,7 @@[m
             [m
             @Html.ActionLink("Edit", "Edit", "Userinfo", new { id = Model.UserInfoID }) |[m
             @Html.ActionLink("Details", "Details", new { id = Model.UserInfoID }) |[m
[31m-            @Html.ActionLink("Delete", "Delete", new { id = Model.UserInfoID })[m
[32m+[m[32m            @Html.ActionLink("Delete", "Delete","Userinfo", new { id = Model.UserInfoID })[m
         </td>[m
     </tr>[m
 [m
[1mdiff --git a/Cv/Views/Userinfo/UserToDoList.cshtml b/Cv/Views/Userinfo/UserToDoList.cshtml[m
[1mnew file mode 100644[m
[1mindex 0000000..ef80f7f[m
[1m--- /dev/null[m
[1m+++ b/Cv/Views/Userinfo/UserToDoList.cshtml[m
[36m@@ -0,0 +1,28 @@[m
[32m+[m[32m﻿@using Microsoft.AspNet.Identity[m
[32m+[m[32m@using Cv.Models;[m
[32m+[m
[32m+[m[32m@{[m
[32m+[m[32m    ViewBag.Title = "User";[m
[32m+[m[32m    Layout = "~/Views/Shared/_Layout.cshtml";[m
[32m+[m
[32m+[m[32m}[m
[32m+[m
[32m+[m[32m<h2>What do you want to do here ?</h2>[m
[32m+[m[32m<div class="container">[m
[32m+[m[32m    <div class="UserForm">[m
[32m+[m[32m        <ul class="list-group">[m
[32m+[m[32m            <li><h4>Personal Information</h4></li>[m
[32m+[m[32m            <hr />[m
[32m+[m[32m            <li class="">@Html.ActionLink("Show my own information", "Show", "Userinfo")</li>[m
[32m+[m[32m            <li class="">@Html.ActionLink("Enter a new personal information", "Create", "Userinfo")</li>[m
[32m+[m[32m            <li class="">@Html.ActionLink("Edit your personal info", "Edit", "Userinfo")</li>[m
[32m+[m[32m            <li class="">@Html.ActionLink("Delete your personal info", "Delete", "Userinfo")</li>[m
[32m+[m[32m            <br />[m
[32m+[m[32m            <li><h4>Education Information</h4></li>[m
[32m+[m[32m            <hr />[m
[32m+[m[32m            <li class="">@Html.ActionLink("Enter an education information", "Create", "Education")</li>[m
[32m+[m[32m            <li class="">@Html.ActionLink("Edit  your education info", "Edit", "Education")</li>[m
[32m+[m[32m            <li class="">@Html.ActionLink("Delete your education info", "Delete", "Education")</li>[m
[32m+[m[32m        </ul>[m
[32m+[m[32m    </div>[m
[32m+[m[32m</div>[m
\ No newline at end of file[m
[1mdiff --git a/Cv/bin/Cv.dll b/Cv/bin/Cv.dll[m
[1mindex 6495356..2ea7c19 100644[m
Binary files a/Cv/bin/Cv.dll and b/Cv/bin/Cv.dll differ
[1mdiff --git a/Cv/bin/Cv.pdb b/Cv/bin/Cv.pdb[m
[1mindex 40c330b..40b4ed4 100644[m
Binary files a/Cv/bin/Cv.pdb and b/Cv/bin/Cv.pdb differ
[1mdiff --git a/Cv/obj/Debug/Cv.csprojResolveAssemblyReference.cache b/Cv/obj/Debug/Cv.csprojResolveAssemblyReference.cache[m
[1mindex 42db9e9..b49fd73 100644[m
Binary files a/Cv/obj/Debug/Cv.csprojResolveAssemblyReference.cache and b/Cv/obj/Debug/Cv.csprojResolveAssemblyReference.cache differ
[1mdiff --git a/Cv/obj/Debug/Cv.dll b/Cv/obj/Debug/Cv.dll[m
[1mindex 6495356..2ea7c19 100644[m
Binary files a/Cv/obj/Debug/Cv.dll and b/Cv/obj/Debug/Cv.dll differ
[1mdiff --git a/Cv/obj/Debug/Cv.pdb b/Cv/obj/Debug/Cv.pdb[m
[1mindex 40c330b..40b4ed4 100644[m
Binary files a/Cv/obj/Debug/Cv.pdb and b/Cv/obj/Debug/Cv.pdb differ
[1mdiff --git a/Cv/obj/Debug/DesignTimeResolveAssemblyReferencesInput.cache b/Cv/obj/Debug/DesignTimeResolveAssemblyReferencesInput.cache[m
[1mindex 0cc08ef..79ced35 100644[m
Binary files a/Cv/obj/Debug/DesignTimeResolveAssemblyReferencesInput.cache and b/Cv/obj/Debug/DesignTimeResolveAssemblyReferencesInput.cache differ
