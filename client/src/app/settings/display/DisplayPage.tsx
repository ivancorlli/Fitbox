'use client'

import { Container, FormLabel, HStack, Switch, useColorMode, VStack } from "@chakra-ui/react"
import GeneralLayout from "../GeneralLayout"


function DisplatPage() {
    const { colorMode, toggleColorMode } = useColorMode()

    return (
        <>
            <Container
                w='100%'
                h='100%'
                maxW={['100%','100%','95%','95%','90%']}
                p='0'

            >

                <GeneralLayout name="Pantalla">
                    <HStack
                        w='100%'
                        paddingY='10px'
                        paddingX='10px'
                        alignItems='center'
                        justifyContent='space-between' >
                        <FormLabel fontSize='md' fontWeight='light' htmlFor='colorMode'>Modo oscuro</FormLabel>
                        <Switch id='colorMode' {...colorMode == 'dark' ? { isChecked: true } : { isChecked: false }} onChange={toggleColorMode} colorScheme='blue'/>
                    </HStack>
                </GeneralLayout>
            </Container>
        </>
    )
}



export default DisplatPage