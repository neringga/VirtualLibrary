import React, { Component } from "react";
import decode from "jwt-decode";

export const loggedIn = () => {
  const token = localStorage.getItem("id_token");
  if (!token) {
    return false;
  }
  try {
    const { Name } = decode(token);
    console.log(Name + "a");
  } catch (e) {
    return false;
  }
  return true;
};

export const setToken = idToken => {
  localStorage.setItem("id_token", idToken);
};

export const getToken = () => {
  return localStorage.getItem("id_token");
};

export const logout = () => {
  localStorage.removeItem("id_token");
};

export const getProfile = () => {   //NOT TESTED
  return decode(this.getToken()).unique_name;
};
