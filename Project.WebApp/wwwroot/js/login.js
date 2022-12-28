// login
$("#btn").click(function (e) {
    e.preventDefault();
    var valdata = $("#form-login").serialize();

    $.ajax({
        url: "http://localhost:5150/api/Login",
        type: "POST",
        data: valdata,
        success: function (response) {

            swal({
                icon: "success",
                buttons: false,
                timer: 2000,
            });

            setTimeout(function () {
                window.location.href = "http://localhost:5149/Client";
            }, 2000);
            console.log(response)
        },
        error: function (err) {
            swal({
                text: "Email ou senha inválidos.",
                icon: "error",
            });
            console.log(err)
        }
    });
});

// register
$("#btn-register").click(function (e) {
    e.preventDefault();
    var valdata = $("#form-register").serialize();
    console.log(valdata)
    $.ajax({
        url: "http://localhost:5150/api/User",
        type: "POST",
        data: valdata,
        success: function (response) {
            swal({
                title: "Usuário criado!",
                text: "Usuário criado com sucesso!",
                icon: "success",
                buttons: false,
                timer: 2000,
            });
            setTimeout(function () {
                window.location.href = "http://localhost:5149/";
            }, 2000);
            console.log(response)
        },
        error: function (err) {
            swal({
                text: "Preencha todos os campos!",
                icon: "error",
            });

            console.log(err)
        }
    });
});