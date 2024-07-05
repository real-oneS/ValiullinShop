const form = document.getElementById('orderForm');
form.addEventListener('submit', function (event) {
    const firstName = document.getElementById('firstName').value;
    const lastName = document.getElementById('lastName').value;
    const middleName = document.getElementById('middleName').value;
    const phone = document.getElementById('phone').value;
    const email = document.getElementById('email').value;
    const address = document.getElementById('address').value;
    const paymentMethod = document.getElementById('paymentMethod').value;

    if (!firstName || !lastName || !phone || !email || !address || !paymentMethod) {
        event.preventDefault();
        document.getElementById('firstNameError').innerText = firstName ? '' : 'Введите имя';
        document.getElementById('lastNameError').innerText = lastName ? '' : 'Введите фамилию';
        document.getElementById('middleNameError').innerText = middleName ? '' : '';
        document.getElementById('phoneError').innerText = phone ? '' : 'Введите номер телефона';
        document.getElementById('emailError').innerText = email ? '' : 'Введите корректный Email';
        document.getElementById('addressError').innerText = address ? '' : 'Введите ваш адрес';
        document.getElementById('paymentMethodError').innerText = paymentMethod ? '' : 'Выберите способ оплаты';
    }
});