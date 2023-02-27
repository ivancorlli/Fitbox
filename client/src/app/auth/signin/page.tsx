'use client'

import SocialButton from "@/components/button/SocialButton";
import { Button, Container, Divider, Input, InputGroup, InputLeftElement, InputRightElement, Text, useColorMode, VStack } from "@chakra-ui/react";
import { signIn } from "next-auth/react";
import { useState } from "react";
import { SlEnvolope, SlEye } from "react-icons/sl";
import { RxEyeClosed } from 'react-icons/rx'
import { FaFacebook, FaGoogle } from 'react-icons/fa'
import MenuContentLayout from "@/components/layout/MenuContentLayout";



export default function Page() {
    const { colorMode } = useColorMode()
    return (
        <>
            <MenuContentLayout>

                <Container h='90%' w='100%' display='flex' flexDirection='column' justifyContent='center' >

                    <VStack
                        border='1px'
                        borderColor={colorMode == 'light' ? 'gray.100' : 'whiteAlpha.200'}
                        py='30px'
                        spacing='12'
                        borderRadius='16px'
                        px='10px'
                        >
                        <VStack
                            alignItems='start'
                            spacing={2}
                            w='100%'
                            px={['10px', '90px', '90px']}
                        >
                            <Text
                                fontSize='4xl'
                                fontWeight='extrabold'
                            >
                                Iniciar Sesion
                            </Text>
                            <VStack>

                                <Text
                                    color={colorMode == 'light' ? 'gray.500' : 'whiteAlpha.700'}
                                >
                                    Bienvenido de vuelta
                                </Text>
                                <Text
                                    color={colorMode == 'light' ? 'gray.500' : 'whiteAlpha.700'}
                                >
                                    Te hemos extrañado !
                                </Text>
                            </VStack>
                        </VStack>
                        <VStack spacing={5}>
                            <LoginForm />
                            <Divider />
                            <VStack spacing={2}>
                                <SocialButton
                                    color={colorMode == 'light' ? '#4267B2' : 'white'}
                                    border={colorMode == 'light' ? '1px' : 'none'}
                                    bg={colorMode == 'light' ? 'none' : '#4267B2'}
                                    icon={<FaFacebook />}
                                    onClick={() => signIn('facebook')}
                                    hover={{
                                        bg: colorMode == 'light' ? '#4267B2' : 'blue.500',
                                        color: 'white',
                                        border: 'none'
                                    }}
                                >
                                    Iniciar con facebook
                                </SocialButton>
                                <SocialButton
                                    color={'black'}
                                    border={colorMode == 'light' ? '1px' : 'none'}
                                    bg={colorMode == 'light' ? 'none' : 'whiteAlpha.800'}
                                    icon={<FaGoogle />}
                                    onClick={() => signIn('google', { callbackUrl: '/' })}
                                    hover={{
                                        bg: colorMode == 'light' ? 'black' : 'white',
                                        border: 'none',
                                        color: colorMode == 'light' ? 'white' : 'black'
                                    }}
                                >
                                    Iniciar con google
                                </SocialButton>
                            </VStack>
                        </VStack>
                    </VStack>
                </Container>
            </MenuContentLayout>
        </>
    )
}


function LoginForm() {
    const [show, setShow] = useState(false)
    const handleClick = () => setShow(!show)
    return (
        <>
            <VStack w='100%'
                spacing={5}
            >
                <VStack
                    w='100%'
                >

                    <InputGroup>
                        <InputLeftElement
                            pointerEvents='none'
                            children={<SlEnvolope color='gray.300' />}
                        />
                        <Input type='text' placeholder='Email o Nombre de usuario' />
                    </InputGroup>
                    <InputGroup>
                        <Input
                            pr='4.5rem'
                            type={show ? 'text' : 'password'}
                            placeholder='Contraseña'
                        />
                        <InputRightElement width='4.5rem'>
                            <Button h='1.75rem' size='sm' onClick={handleClick}>
                                {show ? <RxEyeClosed /> : <SlEye />}
                            </Button>
                        </InputRightElement>
                    </InputGroup>
                </VStack>
                <VStack
                    w='100%'
                >
                    <Button
                        w='100%' bg='blue.400' color='white'
                        _hover={{
                            background: 'blue.600',
                            color: 'white'
                        }}
                        _pressed={{
                            background: 'blue.600',
                            color: 'white'
                        }}
                    >
                        Iniciar Sesion
                    </Button>
                </VStack>
            </VStack>

        </>
    )
}