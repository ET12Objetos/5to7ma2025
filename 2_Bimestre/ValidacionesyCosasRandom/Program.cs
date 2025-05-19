using ValidacionesyCosasRandom;

ValidarEmail validadorEmail = new ValidarEmail();

validadorEmail.ValidarConEmailValidation("mail@mail.com");

validadorEmail.ValidarConExpresionRegular("mail@mail.com");

ValidarCuit validadorCuit = new ValidarCuit();

validadorCuit.Validar("20-33157849-6");