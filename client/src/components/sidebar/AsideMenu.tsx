'use client'

import FitboxBlue25 from "@/public/icon/FitboxBlue25"
import FitboxWhite25 from "@/public/icon/FitboxWhite25"
import { Container, Divider, Icon, useColorMode, VStack } from "@chakra-ui/react"
import { SignInButton, SignUpButton } from "../button/RegisterButton"
import { NonSessionMenu } from "../menu/Menu"



function AsideMenu() {
    const { colorMode } = useColorMode()
    return (
        <>
            <VStack w='100%' h='100%' maxW='250px'
                spacing={10} paddingY='15px'
                justifyContent='space-between'
                borderRight='1px'
                borderColor={colorMode == 'light' ? 'gray.100' : 'whiteAlpha.200'}
            >
                <Container w='100%' >
                    <VStack w='100%' spacing={5} alignItems='start' paddingX='10px' >
                        <Icon as={colorMode == 'light' ? FitboxBlue25 : FitboxWhite25} />
                        <NonSessionMenu />
                    </VStack>
                </Container>
                <Container w='100%' >
                    <VStack w='100%' spacing={5}>
                        <Divider />
                        <SignInButton />
                        <SignUpButton />
                    </VStack>
                </Container>
            </VStack>
        </>
    )
}

export default AsideMenu