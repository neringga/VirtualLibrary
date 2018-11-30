import decode from "jwt-decode";

export const loggedIn = () => {
  const token = getToken();
  console.log(token);
  if (!token) {
    return false;
  }
  try {
    const name = decode(token);
  } catch (e) {
    return false;
  }
  return true;
};

export const setToken = idToken => {
  localStorage.setItem("token", idToken);
};

export const getToken = () => {
  return localStorage.getItem("token");
};

export const logout = () => {
  localStorage.removeItem("token");
};

export const getProfile = () => {   //NOT TESTED
  return decode(this.getToken()).unique_name;
};
