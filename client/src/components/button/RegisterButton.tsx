import { Button, VStack } from "@chakra-ui/react";
import { useRouter } from "next/navigation";

function RegisterButton() {
    return (
        <>
            <VStack align='start'>
               <SignInButton/>
               <SignUpButton/>
            </VStack>
        </>
    );
}

function SignInButton()
{
    const {push} = useRouter()
    return(
        <Button maxW='95%' w='100%' bg='blue.400' color='white' 
                _hover={{
                    background:'blue.600',
                    color:'white'
                }}
                _pressed={{
                    background:'blue.600',
                    color:'white'
                }}
                onClick={()=>push('/api/auth/signin')}
                >
                    Iniciar Sesion
                </Button>
    )
}

function SignUpButton()
{
    const {push} = useRouter()
    return(
        <Button maxW='95%' w='100%' variant='outline' color='blue.400' borderColor='blue.400'
        _hover={{
            borderColor:'blue.600',
            color:'blue.600'
        }}
        _pressed={{
            borderColor:'blue.600',
            color:'blue.600'
        }}
        // onClick={}
        >
            Registrarse
        </Button>
    )
}

export {
    SignInButton,
    SignUpButton
}
export default RegisterButton