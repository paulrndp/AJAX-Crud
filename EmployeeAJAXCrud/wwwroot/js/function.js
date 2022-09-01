$(document).ready(function () {
    //alert('page load successfully.');
    LoadData();
});

function LoadData() {
    $.ajax({
        url: "/Home/GetAll",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.id + '</td>';
                html += '<td>' + item.fullname + '</td>';
                html += '<td>' + item.position + '</td>';
                html += '<td><a href="" onclick="return GetOne(' + item.id + ')" data-bs-toggle="modal" data-bs-target="#editModal">Edit</a> | <a href="" onclick="return Delete(' + item.id + ')" >Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}
function GetOne(id) {
    $.ajax({
        url: "/Home/GetOne/" + id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        data: { id: id },
        success: function (data) {
            $('#editID').val(data.id);
            $('#editFullname').val(data.fullname);
            $('#editPosition').val(data.position);
            $('#editModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}
function Delete(id) {
    if (confirm('Are you sure you want to delete this thing into the database?')) {
        $.ajax({
            url: "/Home/Remove/" + id,
            typr: "GET",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            data: { id: id },
            success: function (data) {
                LoadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });

    } else {

    }

    return false;
}

$('#Save').click(function () {
    var fullname = $("#fullname").val();
    var position = $("#position").val();

    var pdata = new Object();
    pdata.fullname = fullname;
    pdata.position = position;

    $.ajax({
        type: 'POST',
        url: '/Home/Save',
        data: pdata,
        success(data) {
            if (data == 'pass') {
                $('#newModal').modal('hide');
                LoadData();
            }
            else {
                alert('failed');
            }
        }
    });
})
$('#Update').click(function () {
    var id = $("#editID").val();
    var fullname = $("#editFullname").val();
    var position = $("#editPosition").val();

    var pdata = new Object();
    pdata.id = id;
    pdata.fullname = fullname;
    pdata.position = position;

    $.ajax({
        type: 'POST',
        url: '/Home/Save',
        data: pdata,
        success(data) {
            if (data == 'pass') {
                $('#editModal').modal('hide');
                LoadData();
            }
            else {
                alert('failed');
            }
        }
    });
})


