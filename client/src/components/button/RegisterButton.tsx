import { Button, VStack } from "@chakra-ui/react";

function RegisterButton() {
    return (
        <>
            <VStack align='start'>
                <Button maxW='95%' w='100%' bg='blue.400' color='white' 
                _hover={{
                    background:'blue.600',
                    color:'white'
                }}
                _pressed={{
                    background:'blue.600',
                    color:'white'
                }}
                >
                    Iniciar Sesion
                </Button>
                <Button maxW='95%' w='100%' variant='outline' color='blue.400' borderColor='blue.400'
                _hover={{
                    borderColor:'blue.600',
                    color:'blue.600'
                }}
                _pressed={{
                    borderColor:'blue.600',
                    color:'blue.600'
                }}
                
                >
                    Registrarse
                </Button>
            </VStack>
        </>
    );
}
export default RegisterButton