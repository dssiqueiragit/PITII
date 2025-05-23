var $j = jQuery.noConflict();
$j(document).ready(function(){
	var InitMask = function () {
		$j('#RadTextBox_LOGIN_USER_LOGIN').mask('999.999.999-99');
		$j('#txtLoginPassword').mask('I', {
			onKeyPress: function (value, event) {
				event.currentTarget.value = value.toUpperCase();
			}
		});
		$j('#RadTextBox_LOGIN_USER_NAME').mask('I', {
			onKeyPress: function (value, event) {
				event.currentTarget.value = value.toUpperCase();
			}
		});
		$j('#RadTextBox_LOGIN_USER_CEP').mask('99999-999');
		$j('#RadTextBox_LOGIN_USER_EMAIL').mask('M', {
			onKeyPress: function (value, event) {
				event.currentTarget.value = value.toLowerCase();
			}
		});
		$j('#RadTextBox_LOGIN_USER_CEL').mask('(99)99999-9999');
		$j('#RadTextBox_LOGIN_USER_OBS').mask('I', {
			onKeyPress: function (value, event) {
				event.currentTarget.value = value.toUpperCase();
			}
		});
	};
	InitMask();
	var prm = Sys.WebForms.PageRequestManager.getInstance();
	if (prm != null) {
		prm.add_endRequest(function (sender, e) {
			if (sender._postBackSettings.panelsToUpdate != null) {
				InitMask();
			}
		});
	};
 });
