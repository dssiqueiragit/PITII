function alert(title, text, icon, callback)
{
	swal.fire(title, text, icon, callback)
	.then((result) => {
		callback();
	});
}
