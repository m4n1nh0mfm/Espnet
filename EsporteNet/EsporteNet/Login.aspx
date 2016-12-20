<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EsporteNet.Login" %>

<!DOCTYPE html>
<!-- saved from url=(0054)http://bootsnipp-env.elasticbeanstalk.com/iframe/33oeD -->
<html lang="en"><head><meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
    
    <meta name="robots" content="noindex">

    <title>Login BootStrap - Bootsnipp.com</title>
        <meta name="viewport" content="width=device-width, initial-scale=1">
    <link href="css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
    <style type="text/css">
    .wrapper{
    margin-top: 45px;
}
.form-signin{
  max-width: 420px;
  padding: 30px 38px 66px;
  margin: 0 auto;
  border: 1px solid #cccccc;
}
.input-group{
    height: 45px;
    margin-bottom: 15px;
    border-radius: 0px;
    color: #60B99A;
}
.form-control{
    height: 45px;
    color: #60B99A;
}
.input-group:hover span i{
    color: #60B99A;
}
.btn-block{
    border-radius: 0px;
    margin-top: 25px;
    background-color: #60B99A;
    border: none;
}
.btn-block:hover{
    background-color: #D3CE3D;
}
.bol{
    position: relative;
    margin-top: -40px;
    color: #60B99A;
}
    </style>
    <script src="js/jquery-1.10.2.min.js.download"></script>
    <script src="js/bootstrap.min.js.download"></script>
    <script type="text/javascript">
        window.alert = function(){};
        var defaultCSS = document.getElementById('bootstrap-css');
        function changeCSS(css){
            if(css) $('head > link').filter(':first').replaceWith('<link rel="stylesheet" href="'+ css +'" type="text/css" />'); 
            else $('head > link').filter(':first').replaceWith(defaultCSS); 
        }
        $( document ).ready(function() {
          var iframe_height = parseInt($('html').height()); 
          window.parent.postMessage( iframe_height, 'http://bootsnipp.com');
        });
    </script>
</head>
<body>
	 <link rel="stylesheet" href="css/font-awesome.min.css">
 <div class="container">
            <div class="wrapper">
                <form name="Login_Form" class="form-signin" runat="server"> 
                     <div class="row text-center bol"><i class="fa fa-circle"></i></div>
                    <h3 class="form-signin-heading text-center">
                        <img src="http://codigocomcafe.com.br/demo/form/image/logo.png" alt="">
                    </h3>
                    <hr class="spartan">
                    <div class="input-group">
                        <span class="input-group-addon" id="sizing-addon1">
                            <i class="fa fa-user"></i>
                        </span>
                       <input type="text" class="form-control" name="Username" placeholder="Username" required="" autofocus="">
                    </div>
                    <div class="input-group">
                        <span class="input-group-addon" id="sizing-addon1">
                            <i class="fa fa-lock"></i>
                        </span>
                       <input type="password" class="form-control" name="Password" placeholder="Password" required="">         	  
                    </div>
                    <button class="btn btn-lg btn-primary btn-block" name="Submit" value="Entrar" type="Submit">Entrar</button>  			
                </form>			
            </div>
</div>
	<script type="text/javascript">
	
	</script>


</body></html>