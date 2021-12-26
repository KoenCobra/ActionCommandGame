window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            "Success!",
            message,
            "success"
        );
    }
    if (type === "error") {
        Swal.fire(
            "Something went wrong",
            message,
            "error"
        );
    }
}

window.PlaySound = function() {
    document.getElementById('sound').play();
}