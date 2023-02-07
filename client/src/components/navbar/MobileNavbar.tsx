'use client'
import FitboxBlue from "@/public/icon/FitboxBlue25"
import FitboxWhite25 from "@/public/icon/FitboxWhite25"
import { Grid, GridItem, IconButton, useColorMode } from "@chakra-ui/react"
import { useRouter } from "next/navigation"
import Menu from "../menu/Menu"


function MobileNavbar({icon}:{icon:boolean}) {
    const router = useRouter()
    const {colorMode} = useColorMode()

    function BackHomeHandler() {
        return router.push('/')
    }
    return (
        <>
            <Grid as='nav' 
            w='100%' 
            templateColumns={icon ? 'repeat(2, 1fr)' : 'repeat(1, 1fr)'} 
            paddingY='6px'
            paddingX='4px'
            alignItems='center'
            position='sticky'
            top='0'
            bg={colorMode == 'light' ? 'white' : 'dark'}
            > 
                <GridItem w='100%'>
                    <Menu />
                </GridItem>
                {
                icon ?
                <GridItem w='100%'>
                    {
                        colorMode == 'light' ?
                        <IconButton  
                        icon={<FitboxBlue/>} 
                        bg='none' 
                        aria-label="Back Home" 
                        onClick={BackHomeHandler} 
                        _pressed={{background:'none'}}
                        _hover={{background:'none'}}
                        size='xs'
                        />   
                        :
                        <IconButton  
                        icon={<FitboxWhite25/>} 
                        bg='none' 
                        aria-label="Back Home" 
                        onClick={BackHomeHandler} 
                        _pressed={{background:'none'}}
                        _hover={{background:'none'}}
                        size='xs'
                        />   
                    }
                </GridItem>
                :''
                }
            </Grid>
        </>
    )
}

export default MobileNavbar