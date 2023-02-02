import { Button, VStack } from "@chakra-ui/react";

function RegisterButton() {
    return (
        <>
            <VStack align='start'>
                <Button maxW='95%' w='100%' bg='blue.400' color='white'>
                    Iniciar Sesion
                </Button>
                <Button maxW='95%' w='100%' variant='outline' color='cyan.400' borderColor='cyan.400'>
                    Registrarse
                </Button>
            </VStack>
        </>
    );
}
export default RegisterButton