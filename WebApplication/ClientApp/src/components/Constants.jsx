import * as React from 'react';

export const HttpRequestPath = "http://localhost:50898/"
export const userRegistrationApi = "api/UserRegistration/5"
export const userSignInApi = "api/UserSignIn/5"
export const emailRegex = new RegExp(/^\S+@\S+\.\S+$/)
export const passordNotMatchErr = "Passwords don't match"
export const usernameShortErr = "Username is too short"
export const emailRegexErr = "Incorrect email"
export const successfullRegistration = "Registered successfully"
export const emailRegisteredErr = "This email is already registered"
export const usernameRegisteredErr = "This username is already registered"
export const noUser = "User not found"
export const noUsername = "Please type in your username"
export const noPassword = "Please type in your password"
export const successfullSignIn = "You are logged in"
export const emailErr = 0
export const usernameErr = 1