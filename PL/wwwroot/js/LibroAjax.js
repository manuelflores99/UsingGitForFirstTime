$(document).ready(function () {
    GetAll();
});

function GetAll() {

    $.ajax({
        url: "https://localhost:7116/api/Libro/GetAll",
        type: "GET",
        crossDomain: true,
        dataType: "JSON",
        success: function (result) {
            console.log(result);
            if (result.success) {
                $.each(result.data, function (i, libro) {
                    $("#showLibros").append("<tr>" +
                        "<td><button type='button' class='btn btn-success' onclick='GetById(" + libro.idLibro + ")' >Editar</button></td>" +
                        "<td>" + libro.titulo + "</td>" +
                        "<td>" + libro.autor + "</td>" +
                        "<td>" + libro.isbn + "</td>" +
                        "<td>" + libro.anioPublicacion + "</td>" +
                        "<td>" + libro.editorial.nombre + "</td>" +
                        "<td>" + libro.ciudad.nombreCiudad + "</td>" +
                        "<td><button type='button' class='btn btn-danger' onclick='Delete(" + libro.idLibro + ")'>Eliminar</button></td>" +
                        "</tr>"
                    );
                })
            }
        },
        error: function (error) {
            alert('Error en la conexion');
        }
    });
}

function GetById(idLibro) {
    $("#btnModal").click();
    $("#textTituloModal").text("Editar Libro");

    $.ajax({
        url: "https://localhost:7116/api/Libro/GetById/" + idLibro,
        type: "GET",
        crossDomain: true,
        dataType: "JSON",
        success: function (result) {

            var stringyear = result.data.anioPublicacion;

            var anio = parseInt((stringyear));

            if (result.data) {
                $("#ddlIdLibro").val(result.data.idLibro);
                $("#ddlTitulo").val(result.data.titulo);
                $("#ddlAutor").val(result.data.autor);
                $("#ddlIsbn").val(result.data.isbn);
                $("#ddlAnio").val(anio);

                $($("#ddlEditorial")[0][0]).val(result.data.editorial.idEditorial);
                $($("#ddlEditorial")[0][0]).text(result.data.editorial.nombre);

                $("#btnUpd").show();
                $("#btnAdd").hide();
            }
        },
        error: function (error) {
            alert('Error en la conexion');
        }
    });
}

function Update() {

    if (ValidarCampos()) {

        var yearNumber = $("#ddlAnio").val();
        var fecha = new Date(yearNumber, 0);

        $.ajax({
            url: "https://localhost:7116/api/Libro/Update",
            type: "PUT",
            crossDomain: true,
            dataType: "JSON",
            contentType: 'application/json',
            data: JSON.stringify({
                idEmpledo: parseInt($("#ddlIdLibro").val()),
                titulo: $("#ddlTitulo").val(),
                autor: $("#ddlAutor").val(),
                iSBN: $("#ddlIsbn").val(),
                anioPublicacion: fecha,
                editorial: {
                    idEditorial: $("#ddlEditorial").val(),
                    ciudad: {
                        idCiudad: $("#ddlCiudad").val()
                    }
                }
            }),
            success: function (result) {
                GetAll();
                $("#btnExit").click();
                alert("Registro Actualizado");
            },
            error: function (error) {
                alert('Error en la conexion');
            }
        });
    }
}



function Add() {

    if (ValidarCampos()) {

        var yearNumber = $("#ddlAnio").val();
        var fecha = new Date(yearNumber, 0);

        $.ajax({
            url: "https://localhost:7116/api/Libro/Add",
            type: "POST",
            crossDomain: true,
            dataType: "JSON",
            contentType: 'application/json',
            data: JSON.stringify({

                titulo: $("#ddlTitulo").val(),
                autor: $("#ddlAutor").val(),
                iSBN: $("#ddlIsbn").val(),
                anioPublicacion: fecha,
                editorial: {
                    idEditorial: $("#ddlEditorial").val(),
                    ciudad: {
                        idCiudad: $("#ddlCiudad").val()
                    }
                }
            }),
            success: function (result) {
                GetAll();
                $("#btnExit").click(); //CloseModal
                alert("Registro Agregado");
            },
            error: function (error) {
                alert('Error en la conexion');
            }
        });

    }
}


function Limpiar() {

    document.getElementById('ddlTitulo').value = ' ';
    document.getElementById('ddlAutor').value = ' ';
    document.getElementById('ddlIsbn').value = ' ';
    document.getElementById('ddlAnio').value = ' ';

    GetAllEditoriales();
  
    $("#btnAdd").show();
    $("#btnUpd").hide();
}

function Delete(idLibro) {
    if (alert("¿Seguro que quieres eliminar este registro?")) {
        $.ajax({
            url: "https://localhost:7116/api/Libro/Delete/" + idLibro,
            type: "DELETE",
            crossDomain: true,
            dataType: "JSON",
            success: function (result) {
                alert('Registro Eliminado Correctamente');
            },
            error: function (error) {
                alert('Error en la conexion');
            }
        });
    };
}


function GetAllEditoriales() {

    $("#ddlEditorial").empty();
    $("#ddlEditorial").append("<option value = '0' >Selecciona una opcion</option>");

    $.ajax({
        url: "https://localhost:7116/api/Editorial/GetAll",
        type: "GET",
        crossDomain: true,
        dataType: "JSON",
        success: function (result) {
            if (result.data) {
                $.each(result.data, function (i, data) {
                    $('#ddlEditorial').append('<option value =' + data.idEditorial + '>' + data.nombre + '</option>');

                })
            }
        },
        error: function (error) {
            alert('Error en la conexion');
        }
    });
}

//function GetAllCiudades() {

//    $("#ddlCiudad").empty();
//    $("#ddlCiudad").append("<option value = '0' >Selecciona una opcion</option>");

//    $.ajax({
//        url: "https://localhost:7116/api/Ciudad/GetAll",
//        type: "GET",
//        crossDomain: true,
//        dataType: "JSON",
//        success: function (result) {
//            if (result.data) {
//                $.each(result.data, function (i, data) {
//                    $('#ddlCiudad').append('<option value =' + data.idCiudad + '>' + data.nombreCiudad + '</option>');
//                })
//            }
//        },
//        error: function (error) {
//            alert('Error en la conexion');
//        }
//    });
//} 

function ShowBtn() {
    $("#btnModal").click();
    $("#btnAdd").hide();
    $("#btnUpd").show();
}


function SoloLetras(input, label) {

    var teclas = $(input).val();
    var regex = /^[a-zA-Z\s]+$/;

    if (regex.test(teclas)) {

        $('#' + label).text("");
        $(input).css({ "boder-color": "green", "background-color": "green" });
    }
    else {
        $('#' + label).text("Solo se permiten letras");
        $(input).css({ "boder-color": "red", "background-color": "red" });

    }
    setTimeout(function () {

        $(input).css({ "border-color": "", "background-color": "" });
    }, 3000);
}


function LetrasYNumeros(input, label) {

    var teclas = $(input).val();
    var regex = /^[a-zA-Z0-9\s]*$/;

    if (regex.test(teclas)) {

        $('#' + label).text("");
        $(input).css({ "boder-color": "green", "background-color": "green" });
    }
    else {
        $('#' + label).text("Solo se permiten letras y numeros");
        $(input).css({ "boder-color": "red", "background-color": "red" });
    }

    setTimeout(function () {

        $(input).css({ "border-color": "", "background-color": "" });
    }, 3000);

}

function Isbn(input, label) {

    var teclas = $(input).val();
    var regex = /^[0-9-]{17}$/;
    //var regex = /^[0-9-]*$/;

    if (regex.test(teclas)) {

        $('#' + label).text("");
        $(input).css({ "boder-color": "green", "background-color": "green" });
    }
    else {
        $('#' + label).text("Solo se permiten numeros, guiones medios y 17 caracteres");
        $(input).css({ "boder-color": "red", "background-color": "red" });
    }

    setTimeout(function () {

        $(input).css({ "border-color": "", "background-color": "" });
    }, 3000);

}


function SoloNumeros(input, label) {

    var teclas = $(input).val();
    var regex = /^[0-9]+$/;

    if (regex.test(teclas)) {
        $('#' + label).text("");
        $(input).css({ "boder-color": "green", "background-color": "green" });
    }
    else {
        $('#' + label).text("Solo se permiten numeros");
        $(input).css({ "boder-color": "red", "background-color": "red" });
    }

    setTimeout(function () {
        $('#' + label).text("");
        $(input).css({ "border-color": "", "background-color": "" });
    }, 3000);

}

function ValidarCampos() {

    var titulo = document.getElementById('ddlTitulo').value.trim();
    var autor = document.getElementById('ddlAutor').value.trim();
    var isbn = document.getElementById('ddlIsbn').value.trim();
    var anio = document.getElementById('ddlAnio').value.trim();
    var editorial = document.getElementById('ddlEditorial').value;


    if (editorial === "0") {
        alert("Por favor completa todos los campos.");
        return false; // Detener la ejecución
    }
    else if (titulo === "") {
        alert("Por favor completa todos los campos.");
        return false; // Detener la ejecución
    }
    else if (autor === "") {
        alert("Por favor completa todos los campos.");
        return false; // Detener la ejecución
    }
    else if (anio === "") {
        alert("Por favor completa todos los campos.");
        return false; // Detener la ejecución
    }
    else if (isbn === "") {
        alert("Por favor completa todos los campos.");
        return false; // Detener la ejecución
    }
    return true;
  
}
