// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your Javascript code.

function alert() {
    event.preventDefault();
    Swal.fire({
        title: 'Are you sure?',
        text: "You will be logged out!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, log out!'
    }).then((result) => {
        if (result.value) {
            Swal.fire({
                icon: 'success',
                title: 'Succesfully logged out.',
                showConfirmButton: false,
                timer: 2000
            })
            var millisecondsToWait = 2000;
            setTimeout(function () {
                // Whatever you want to do after the wait
                //Change this to where you're hosting...for logout
                window.location = "https://localhost:44338/";
            }, millisecondsToWait);
            
        }
    })
}


