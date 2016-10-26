using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using prjJobLogger;

namespace utpJobLogger
{
    [TestClass]
    public class ConsoleLogTest
    {

        #region "Registro unicamente de Mensajes"

            /// <summary>
            /// Verificamos que no haya problemas al escribir el mensaje en consola.
            ///</summary>
            [TestMethod]
            public void WriteMessageTest()
            {
                JobLogger C1 = retornarLogger(configLogger.soloMensajes);

                int expectedResponse = 1;

                Assert.AreEqual(expectedResponse, C1.LogMessage("Message Test", LogType.Message));
            }

            /// <summary>
            /// Seteamos la clase para que únicamente registre Mensajes (no Errores ni Warnings). Luego el test verifica que 
            /// se lance una excepción cuando se intente registrar un Error en lugar de un mensaje.
            ///</summary>
            [TestMethod]
            public void OnlyMessageTest1()
            {
                JobLogger C1 = retornarLogger(configLogger.soloMensajes);

                try
                {
                    C1.LogMessage("Error Test", LogType.Error);
                }
                catch (Exception e)
                {
                    StringAssert.Contains(e.Message, "The type of the message does not match with the configured type(s)");
                    return;
                }

                Assert.Fail("The expected exception didn't appear");
            }

            /// <summary>
            /// Seteamos la clase para que únicamente registre Mensajes (no Errores ni Warnings). Luego el test verifica que 
            /// se lance una excepción cuando se intente registrar un Warning en lugar de un mensaje.
            ///</summary>
            [TestMethod]
            public void OnlyMessageTest2()
            {
                JobLogger C1 = retornarLogger(configLogger.soloMensajes);

                try
                {
                    C1.LogMessage("Warning Test", LogType.Warning);
                }
                catch (Exception e)
                {
                    StringAssert.Contains(e.Message, "The type of the message does not match with the configured type(s)");
                    return;
                }

                Assert.Fail("The expected exception didn't appear");
            }

        #endregion


        #region #region "Registro unicamente de Warnings"

            /// <summary>
            /// Verificamos que no haya problemas al escribir el Warning en consola.
            ///</summary>
            [TestMethod]
            public void WriteWarningTest()
            {
                JobLogger C1 = retornarLogger(configLogger.soloWarnings);

                int expectedResponse = 1;

                Assert.AreEqual(expectedResponse, C1.LogMessage("Warning Test", LogType.Warning));
            }

            /// <summary>
            /// Seteamos la clase para que únicamente registre Warnings (no Errores ni Mensajes). Luego el test verifica que 
            /// se lance una excepción cuando se intente registrar un Error en lugar de un Warning.
            ///</summary>
            [TestMethod]
            public void OnlyWarningTest1()
            {
                JobLogger C1 = retornarLogger(configLogger.soloWarnings);

                try
                {
                    C1.LogMessage("Error Test", LogType.Error);
                }
                catch (Exception e)
                {
                    StringAssert.Contains(e.Message, "The type of the message does not match with the configured type(s)");
                    return;
                }

                Assert.Fail("The expected exception didn't appear");
            }

            /// <summary>
            /// Seteamos la clase para que únicamente registre Warnings (no Errores ni Warnings). Luego el test verifica que 
            /// se lance una excepción cuando se intente registrar un Mensaje en lugar de un Warning.
            ///</summary>
            [TestMethod]
            public void OnlyWarningTest2()
            {
                JobLogger C1 = retornarLogger(configLogger.soloWarnings);

                try
                {
                    C1.LogMessage("Message Test", LogType.Message);
                }
                catch (Exception e)
                {
                    StringAssert.Contains(e.Message, "The type of the message does not match with the configured type(s)");
                    return;
                }

                Assert.Fail("The expected exception didn't appear");
            }

        #endregion


        #region "Registro unicamente de Errores"

            /// <summary>
            /// Verificamos que no haya problemas al escribir el Error en consola.
            ///</summary>
            [TestMethod]
            public void WriteErrorTest()
            {
                JobLogger C1 = retornarLogger(configLogger.soloErrores);

                int expectedResponse = 1;

                Assert.AreEqual(expectedResponse, C1.LogMessage("Error Test", LogType.Error));
            }

            /// <summary>
            /// Seteamos la clase para que únicamente registre Errores (no Warnings ni Mensajes). Luego el test verifica que 
            /// se lance una excepción cuando se intente registrar un Error en lugar de un Warning.
            ///</summary>
            [TestMethod]
            public void OnlyErrorTest1()
            {
                JobLogger C1 = retornarLogger(configLogger.soloErrores);

            try
                {
                    C1.LogMessage("Warning Test", LogType.Warning);
                }
                catch (Exception e)
                {
                    StringAssert.Contains(e.Message, "The type of the message does not match with the configured type(s)");
                    return;
                }

                Assert.Fail("The expected exception didn't appear");
            }

            /// <summary>
            /// Seteamos la clase para que únicamente registre Warnings (no Errores ni Warnings). Luego el test verifica que 
            /// se lance una excepción cuando se intente registrar un Mensaje en lugar de un Warning.
            ///</summary>
            [TestMethod]
            public void OnlyErrorTest2()
            {
                JobLogger C1 = retornarLogger(configLogger.soloErrores);

            try
                {
                    C1.LogMessage("Message Test", LogType.Message);
                }
                catch (Exception e)
                {
                    StringAssert.Contains(e.Message, "The type of the message does not match with the configured type(s)");
                    return;
                }

                Assert.Fail("The expected exception didn't appear");
            }

        #endregion



        private JobLogger retornarLogger(configLogger config)
        {
            JobLogger rpta=null;

            switch (config)
            {
                case configLogger.soloMensajes:
                    rpta = new JobLogger(false, true, false, true, false, false);
                    break;
                case configLogger.soloWarnings:
                    rpta = new JobLogger(false, true, false, false, true, false);
                    break;
                case configLogger.soloErrores:
                    rpta = new JobLogger(false, true, false, false, false, true);
                    break;
            }

            return rpta;
        }
    }
}
