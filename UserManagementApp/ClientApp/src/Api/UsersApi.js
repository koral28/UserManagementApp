export const GetAllUsers = async () => {
    const response = await fetch('users/getAllUsers');
    const data = await response.json();
    return data;
}

export const AddNewUser = async (user) => {
    var jsonData = JSON.stringify(user);
    const requestOptions = {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Accept': 'application/json',
            "Access-Control-Allow-Origin": "*"
        },
        body: jsonData
    };
    const response = await fetch('users/addNewUser', requestOptions);
    const data = await response.json();
    return data;
}

export const DeleteAUser = async (phoneNumber) => {
    const requestOptions = {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(phoneNumber)
    };
    const response = await fetch('users/deleteUser', requestOptions);
}