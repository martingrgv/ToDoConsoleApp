// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function UpdateTodoStatus(checkbox) {
    var todoId = $(checkbox).data('todo-id');
    var isCompleted = checkbox.checked;

    $.ajax({
        url: '/Home/UpdateStatus',
        type: 'POST',
        data: { id: todoId, isCompleted: isCompleted },
        success: function (response) {
            var redirectTo = response.redirectTo;
            console.log(response);
            console.log(redirectTo);
            window.location.href = redirectTo;
        },
        error: function () {
            console.error('Error updating todo status.');
        }
    })
}
