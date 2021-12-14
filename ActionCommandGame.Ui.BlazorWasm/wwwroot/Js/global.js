window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            "Thank You For Shopping!",
            message,
            "success"
        );
    }
    if (type === "error") {
        Swal.fire(
            "Not Enough Money",
            message,
            "error"
        );
    }
}