# FTP Server Checker
This is a small program that allows the user to check whether an FTP server is available. 

## Basic structure
- Library project for the UI-independent functionalities
- Library test project for the test for the library project (MSTest with fluent assertion)
- UI project for presentation - using Windows Forms
- Credentials are not hardcoded, but can be taken from a local file in the temporary directory on partition C

## Programming Language
- C#

## Status
simple connection test functionality usable

![FTP Server Checker Main Form](/README-Images/MainForm.jpg?raw=true "FTP Server Checker")
