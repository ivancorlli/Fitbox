'use client'
import { HStack, Icon, Text } from "@chakra-ui/react"
import { useRouter } from "next/navigation"
import { AiOutlineArrowLeft } from "react-icons/ai"


function InfoNavbar({ name, back,py,px}: { name: string, back: boolean, px?: string, py?: string }) {
    const router = useRouter()
    function ComeBackHandler() {
        router.back()
    }

    return (
        <>
            <HStack spacing={6}
                alignItems='center'
                justifyContent='start'
                paddingY={py ?? '5px'}
                paddingX={px ?? '0px'}
                w='100%'
            >
                {back &&
                    <Icon
                        as={AiOutlineArrowLeft}
                        aria-label='Come Back'
                        bg='none'
                        onClick={ComeBackHandler}
                        p='0'
                        _hover={{
                            background: 'none'

                        }}
                    />}
                <Text fontSize='2xl' fontWeight='bold' >{name}</Text>
            </HStack>
        </>
    )
}

export default InfoNavbar