// requisição para buscar todos os clientes
$(() => {
    $.ajax({
        url: "http://localhost:5150/api/Client",
        type: "GET",
        success: function (response) {

            const data = response.data;

            for (const i in data) {
                const tr = $('<tr>');
                const tdId = $('<td>').append(data[i].id);
                const tdEnterprise = $("<td>").append(data[i].enterprise);
                const tdName = $("<td>").append(data[i].name);
                const tdCnpj = $("<td>").append(data[i].cnpj);

                const tdbtnEdit = $("<td>").append("<button type='button' data-id='" + data[i].id +"' class='btn-edit-click' '>editar</button>");

                tr.append(tdId, tdEnterprise, tdName, tdCnpj, tdbtnEdit);

                $('tbody').append(tr);
            }

            alert('');
            $('btn-edit-click').click(function () {

                alert($(this).data('id'));
            });

            
        },
        error: function (response) {
            console.log(response)
            alert("erro")
        }
    })
})

// cadastro de cliente
$("#btnsubmit").click(function () {
    var valdata = $("#formularioCliente").serialize();
    $.ajax({
        url: "http://localhost:5150/api/Client",
        type: "POST",
        data: valdata,
        success: function (response) {
            swal({
                title: "Cliente criado!",
                text: "Cliente criado com sucesso!",
                icon: "success",
                buttons: false,
                timer: 2000,
            });
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

// visualização de cliente
$('#btnId').click(function (e) {

    var id = $("#id").val();

    $.ajax({
        url: `http://localhost:5150/api/Client/${id}`,
        type: 'GET',
        success: function (response) {

            jQuery('#details').modal('hide');

            var client = response.data;

            $("#empresa").html(client.enterprise);
            $("#nomee").html(client.name);
            $("#cnpjj").html(client.cnpj);
            $("#cepp").html(client.cep);
            $("#cidade").html(client.county);
            $("#bairro").html(client.district);
            $("#rua").html(client.street);
            $("#numero").html(client.number);
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

// editar cliente
$("#btnsubmitEdit").click(function () {
    var valdata = $("#formularioEditar").serialize();
    $.ajax({
        url: "http://localhost:5150/api/Client",
        type: "PUT",
        data: valdata,
        success: function (response) {
            swal({
                title: "Cliente Editado!",
                text: "Cliente editado com sucesso!",
                icon: "success",
            });
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

// deletar cliente
$('#btnIdDelete').click(() => {
    var id = $("#idDelete").val();
    $.ajax({
        url: `http://localhost:5150/api/Client/${id}`,
        type: 'GET',
        success: function (response) {
            var client = response.data;

            $("#Empresa").html(client.enterprise);
            $("#Nome").html(client.name);
            $("#Cnpj").html(client.cnpj);
            $("#Cep").html(client.cep);
            $("#Cidade").html(client.county);
            $("#Bairro").html(client.district);
            $("#Rua").html(client.street);
            $("#Numero").html(client.number);

            $('#btnsubmitDelete').click(() => {
                $.ajax({
                    url: `http://localhost:5150/api/Client/${id}`,
                    type: 'DELETE',
                    success: function () {
                        swal({
                            title: "Cliente Deletado!",
                            text: "Cliente deletado com sucesso!",
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