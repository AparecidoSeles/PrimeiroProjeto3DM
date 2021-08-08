export const parseJwt = () =>{
    let base64 = localStorage.getItem('user-token').split('.')[1];

    return JSON.parse(window.atob(base64))
}

export const userAutenticado = () => localStorage.getItem('user-token') !== null;