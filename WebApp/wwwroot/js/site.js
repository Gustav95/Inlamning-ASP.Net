


function validateName(name) {

    const regex = /^[a-zA-Z]+$/;
    return regex.test(name);  
}

function validateEmail(email) {

    const regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$/;
    return regex.test(email);
}

function validateFullName(name) {

    const regex = /^(?![\s.]+$)[a-zA-Z\s.]*$/;
    return regex.test(name);
}

function validateform() {
    document.addEventListener("DOMContentLoaded", () => {
        
        const firstnameInput = document.getElementById("firstname");

        firstnameInput.addEventListener('input', (event) => {
            const firstname = event.target.value;
            if (validateName(firstname)) {
                document.getElementById('faulty-value').innerHTML = 'valid';
            } else {
                document.getElementById('faulty-value').innerHTML = 'not valid';
            }
        });

        const lastnameInput = document.getElementById("lastname");

        lastnameInput.addEventListener('input', (event) => {
            const lastname = event.target.value;
            if (validateName(lastname)) {
                document.getElementById('lastname-value').innerHTML = 'valid';
            } else {
                document.getElementById('lastname-value').innerHTML = 'not valid';
            }
        });

        const emailInput = document.getElementById("email");

        emailInput.addEventListener('input', (event) => {
            const email = event.target.value;
            if (validateEmail(email)) {
                document.getElementById('email-value').innerHTML = 'valid';
            } else {
                document.getElementById('email-value').innerHTML = 'not valid';
            }
        });


       
       const confirmpassword = document.getElementById("confirmpassword");
        confirmpassword.addEventListener('change', (event) => {
            const password = document.getElementById("password").value;
            const confirm = event.target.value;

            if (password === confirm) {
                document.getElementById('password-value').innerHTML = 'valid';
            }
            else {
                document.getElementById('password-value').innerHTML = "Password does not match";
            }
        })
        
    });
}

function validatelogin() {
    document.addEventListener("DOMContentLoaded", () => {

        const emailInput = document.getElementById("email");

        emailInput.addEventListener('input', (event) => {
            const email = event.target.value;
            if (validateEmail(email)) {
                document.getElementById('email-value').innerHTML = 'valid';
            } else {
                document.getElementById('email-value').innerHTML = 'not valid';
            }
        });

    });

}

function validatecontact() {
    document.addEventListener("DOMContentLoaded", () => {

        const nameInput = document.getElementById("name");

        nameInput.addEventListener('input', (event) => {
            const name = event.target.value;
            if (validateFullName(name)) {
                document.getElementById('name-value').innerHTML = 'valid';
            } else {
                document.getElementById('name-value').innerHTML = 'not valid';
            }
        });


        const emailInput = document.getElementById("email");

        emailInput.addEventListener('input', (event) => {
            const email = event.target.value;
            if (validateEmail(email)) {
                document.getElementById('email-value').innerHTML = 'valid';
            } else {
                document.getElementById('email-value').innerHTML = 'not valid';
            }
        });


    });

}
