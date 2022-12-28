// requisição para buscar todos os usuarios
$(() => {
    $.ajax({
        url: "http://localhost:5150/api/User",
        type: "GET",
        success: function (response) {

            const data = response.data;

            for (const i in data) {
                const tr = $('<tr>');
                const tdId = $('<td>').append(data[i].id);
                const tdName = $("<td>").append(data[i].name);
                const tdNickname = $("<td>").append(data[i].nickname);
                const tdEmail = $("<td>").append(data[i].email);

                tr.append(tdId, tdName, tdNickname, tdEmail);

                $('tbody').append(tr);
            }
        },
        error: function (response) {
            console.log(response)
            alert("erro")
        }
    })
})

// cadastro de usuarios
$("#btnsubmit").click(function (e) {
    var valdata = $("#formularioUsuario").serialize();
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
            });
            console.log(response)
        },
        error: function (err) {
            swal({
                title: "ERRO!",
                text: "Preencha todos os campos!",
                icon: "error",
            });

            console.log(err)
        }
    });
});

//visualizacao de usuarios
$('#btnId').click(() => {
    var id = $("#id").val();

    $.ajax({
        url: `http://localhost:5150/api/User/${id}`,
        type: 'GET',
        success: function (response) {
            var user = response.data;

            $("#nome").html(user.name);
            $("#nickname").html(user.nickname);
            $("#email").html(user.email);
            $("#password").html(user.password);
            $("#number").html(user.number);
            console.log(response.data)
        },
        error: function (err) {
            swal({
                title: "ERRO!",
                text: "Id inválido!",
                icon: "error",
            });

            console.log(err)
        }
    });
});

// editar usuario
$("#btnsubmitEdit").click(function () {
    var valdata = $("#formularioEditar").serialize();
    $.ajax({
        url: "http://localhost:5150/api/User",
        type: "PUT",
        data: valdata,
        success: function (response) {
            swal({
                title: "Usuário Editado!",
                text: "Usuário editado com sucesso!",
                icon: "success",
            });
            console.log(response)
        },
        error: function (err) {
            swal({
                title: "ERRO!",
                text: "Preencha todos os campos!",
                icon: "error",
            });

            console.log(err)
        }
    });
});

// deletar usuario
var id = $("#idDelete").val();
$('#btnIdDelete').click(() => {
    id = $("#idDelete").val();
    $.ajax({
        url: `http://localhost:5150/api/User/${id}`,
        type: 'GET',
        success: function (response) {
            var user = response.data;

            $("#Nome").html(user.name);
            $("#Nickname").html(user.nickname);
            $("#Email").html(user.email);
            $("#Password").html(user.password);
            $("#Number").html(user.number);
            console.log(response.data)
        },
        error: function (err) {
            swal({
                title: "ERRO!",
                text: "Id inválido!",
                icon: "error",
            });

            console.log(err)
        }
    });
});
$('#btnsubmitDelete').click(() => {
    $.ajax({
        url: `http://localhost:5150/api/User/${id}`,
        type: 'DELETE',
        success: function () {
            swal({
                title: "Usuário Deletado!",
                text: "Usuário deletado com sucesso!",
                icon: "success",
            });
        },
        error: function (error) {
            swal({
                title: "ERRO!",
                text: "ID inválido!",
                icon: "error",
            });

            console.log(err)
        }
    })
})