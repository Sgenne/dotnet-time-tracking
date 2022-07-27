import ProjectPageComponent from "../components/projects/ProjectPageComponent"
import Modal from "../components/utils/Modal"
import withAuthentication from "../higherOrderComponents/WithAuthentication"

const projects = () => {
    return <> 
    <Modal />
    <ProjectPageComponent /> </>
}

export default withAuthentication(projects)