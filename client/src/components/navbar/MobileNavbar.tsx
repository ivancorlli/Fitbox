'use client'
import { Center, Grid, GridItem, IconButton } from "@chakra-ui/react"
import { useRouter } from "next/navigation"
import { SlGhost } from "react-icons/sl"
import Menu from "../menu/Menu"


function MobileNavbar({icon}:{icon:boolean}) {
    const router = useRouter()

    function BackHomeHandler() {
        return router.push('/')
    }
    return (
        <>
            <Grid as='nav' w='100%' templateColumns={icon ? 'repeat(2, 1fr)' : 'repeat(1, 1fr)'} alignItems='center' > 
                <GridItem w='100%'>
                    <Menu />
                </GridItem>
                {
                icon ?
                <GridItem w='100%'>
                        <IconButton icon={<SlGhost />} bg='none' aria-label="Back Home" onClick={BackHomeHandler} />
                </GridItem>
                :''
                }
            </Grid>
        </>
    )
}

export default MobileNavbar