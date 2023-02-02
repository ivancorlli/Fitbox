'use client'
import { HStack, IconButton, Text } from "@chakra-ui/react"
import { useRouter } from "next/navigation"
import { SlArrowLeft } from "react-icons/sl"


function InfoNavbar({ name }: { name: string }) {
    const router = useRouter()
    function ComeBackHandler()
    {
        router.back()
    }

    return (
        <>
            <HStack spacing={6} alignItems='center'>
                <IconButton icon={<SlArrowLeft />} aria-label='Come Back' bg='none' onClick={ComeBackHandler}/>
                <Text fontSize='lg' fontWeight='bold' >{name}</Text>
            </HStack>
        </>
    )
}

export default InfoNavbar