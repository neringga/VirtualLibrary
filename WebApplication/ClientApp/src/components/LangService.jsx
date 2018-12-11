export const setLanguage = language => {
    localStorage.setItem("language", language);
};

export const getLanguage = () => {
    return localStorage.getItem("language");
}
