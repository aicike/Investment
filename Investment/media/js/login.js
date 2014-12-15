var Login = function () {

    return {
        //main function to initiate the module
        init: function () {

            $('.login-form').validate({
                errorElement: 'label', //default input error message container
                errorClass: 'help-inline', // default input error message class
                focusInvalid: false, // do not focus the last invalid input
                rules: {
                    username: {
                        required: true
                    },
                    password: {
                        required: true
                    },
                    remember: {
                        required: false
                    }
                },

                messages: {
                    username: {
                        required: "请输入账号。"
                    },
                    password: {
                        required: "请输入密码。"
                    }
                },

                invalidHandler: function (event, validator, msg) { //display error alert on form submit   
                    if (msg != undefined && msg.length > 0) {
                        $('.alert-error>span').html(msg);
                        $('.alert-error', $('.login-form')).show();
                    } else {
                        $('.alert-error', $('.login-form')).hide();
                    }

                },

                highlight: function (element) { // hightlight error inputs
                    $(element)
                        .closest('.control-group').addClass('error'); // set error class to the control group
                },

                success: function (label) {
                    label.closest('.control-group').removeClass('error');
                    label.remove();
                },

                errorPlacement: function (error, element) {
                    error.addClass('help-small no-left-padding').insertAfter(element.closest('.input-icon'));
                },

                submitHandler: function (form) {
                    $.post(loginUrl, { username: $(form.username).val(), password: $(form.password).val(), role: $(form.role).val(), remember: $(form.remember).val() }, function (result) {
                        if (result.hasError) {
                            $('.alert-error>span').html(result.error);
                            $('.alert-error', $('.login-form')).show();
                        } else {
                            $('.alert-error', $('.login-form')).hide();
                            $('.alert-error>span').html("请输入账号和密码。");
                            window.location.href = "/Home/home";
                        }
                    });
                }
            });

            $('.login-form input').keypress(function (e) {
                if (e.which == 13) {
                    if ($('.login-form').validate().form()) {
                        $.post(loginUrl, { username: $("#username").val(), password: $("#password").val(), role: $("#role").val(), remember: $("#remember").val() }, function (result) {
                            if (result.hasError) {
                                $('.alert-error>span').html(result.error);
                                $('.alert-error', $('.login-form')).show();
                            } else {
                                $('.alert-error', $('.login-form')).hide();
                                $('.alert-error>span').html("请输入账号和密码。");
                                window.location.href = "/Home/home";
                            }
                        });
                    }
                    return false;
                }
            });

            $('.forget-form').validate({
                errorElement: 'label', //default input error message container
                errorClass: 'help-inline', // default input error message class
                focusInvalid: false, // do not focus the last invalid input
                ignore: "",
                rules: {
                    email: {
                        required: true,
                        email: true
                    }
                },

                messages: {
                    email: {
                        required: "请输入邮箱。"
                    }
                },

                invalidHandler: function (event, validator) { //display error alert on form submit   

                },

                highlight: function (element) { // hightlight error inputs
                    $(element)
                        .closest('.control-group').addClass('error'); // set error class to the control group
                },

                success: function (label) {
                    label.closest('.control-group').removeClass('error');
                    label.remove();
                },

                errorPlacement: function (error, element) {
                    error.addClass('help-small no-left-padding').insertAfter(element.closest('.input-icon'));
                },

                submitHandler: function (form) {
                    window.location.href = "index.html";
                }
            });

            $('.forget-form input').keypress(function (e) {
                if (e.which == 13) {
                    if ($('.forget-form').validate().form()) {
                        window.location.href = "index.html";
                    }
                    return false;
                }
            });

            jQuery('#forget-password').click(function () {
                jQuery('.login-form').hide();
                jQuery('.forget-form').show();
            });

            jQuery('#back-btn').click(function () {
                jQuery('.login-form').show();
                jQuery('.forget-form').hide();
            });

            $('.register-form').validate({
                errorElement: 'label', //default input error message container
                errorClass: 'help-inline', // default input error message class
                focusInvalid: false, // do not focus the last invalid input
                ignore: "",
                rules: {
                    username: {
                        required: true
                    },
                    password: {
                        required: true
                    },
                    rpassword: {
                        equalTo: "#register_password"
                    },
                    email: {
                        required: true,
                        email: true
                    },
                    tnc: {
                        required: true
                    }
                },

                messages: { // custom messages for radio buttons and checkboxes
                    tnc: {
                        required: "Please accept TNC first."
                    }
                },

                invalidHandler: function (event, validator) { //display error alert on form submit   

                },

                highlight: function (element) { // hightlight error inputs
                    $(element)
                        .closest('.control-group').addClass('error'); // set error class to the control group
                },

                success: function (label) {
                    label.closest('.control-group').removeClass('error');
                    label.remove();
                },

                errorPlacement: function (error, element) {
                    if (element.attr("name") == "tnc") { // insert checkbox errors after the container                  
                        error.addClass('help-small no-left-padding').insertAfter($('#register_tnc_error'));
                    } else {
                        error.addClass('help-small no-left-padding').insertAfter(element.closest('.input-icon'));
                    }
                },

                submitHandler: function (form) {
                    window.location.href = "Index";
                }
            });

            jQuery('#register-btn').click(function () {
                jQuery('.login-form').hide();
                jQuery('.register-form').show();
            });

            jQuery('#register-back-btn').click(function () {
                jQuery('.login-form').show();
                jQuery('.register-form').hide();
            });
        }

    };

} ();