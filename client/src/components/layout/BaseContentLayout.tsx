import { Container} from "@chakra-ui/react";


interface PageProps {
    children: React.ReactNode
}


export default function BaseContentLayout(props:PageProps)
{
    return(
        <>
        <Container 
                py='5px'
                px='8px'
                h='100%'
                maxW={['100%', '95%', '95%', '95%', '95%', '80%']}
            >
                {props.children}
            </Container>
        
        </>
    )
}