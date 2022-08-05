import styles from "../../styles/projects/ProjectsPageComponent.module.css";
import ControlledStateHandler from "../../types/ControlledStateHandler";
import Project from "../../types/domain/Project";
import PrimaryButton from "../utils/buttons/PrimaryButton";
import ErrorMessage from "../utils/ErrorMessage";
import PlusIcon from "../utils/icons/PlusIcon";
import LoadingSpinner from "../utils/loading/LoadingSpinner";
import Table, { TableItem } from "../utils/Table";
import NewProjectModal from "./NewProjectModal";

export interface ProjectPageComponentProps {
    newProjectNameStateHandler: ControlledStateHandler<string>;
    newProjectDescriptionHandler: ControlledStateHandler<string>;
    userProjects: Project[];
    onCreateNewProject: () => void;
    errorMessage?: string;
    showNewProjectModal: boolean;
    onNewProjectModalOpen: () => void;
    onNewProjectModalClose: () => void;
}

const ProjectPageComponent = ({
    newProjectNameStateHandler,
    newProjectDescriptionHandler,
    userProjects,
    onCreateNewProject,
    errorMessage,
    showNewProjectModal,
    onNewProjectModalOpen,
    onNewProjectModalClose }: ProjectPageComponentProps) => {
    // const [showNewProjectModal, setShowNewProjectModal] = useState(false);

    // const newProjectClickHandler = () => setShowNewProjectModal(true);
    // const newProjectCloseHandler = () => setShowNewProjectModal(false);

    const projectTableItems: TableItem[] = userProjects.map(project => ({
        Project: project.title,
        "Time Status": "7h"
    }))

    const displayedNewProjectModal = showNewProjectModal ? <NewProjectModal
        nameStateHandler={newProjectNameStateHandler}
        descriptionStateHandler={newProjectDescriptionHandler}
        onClose={onNewProjectModalClose}
        onSubmit={onCreateNewProject} /> : <></>

    return (
        <div className={styles["page-container"]}>
            {displayedNewProjectModal}
            <div className={styles["top-bar"]}>
                <h2>Projects</h2>
                <span className={styles["new-project-button-container"]}>
                    <PrimaryButton onClick={onNewProjectModalOpen}>
                        <>
                            <PlusIcon />
                            <span className={styles["new-project-button__text"]}>New Project</span>
                        </>
                    </PrimaryButton>
                </span>
            </div>
            <div className={styles["error-message-container"]}>
                <ErrorMessage>{errorMessage}</ErrorMessage>
            </div>
            {
                userProjects
                    ?
                    <div className={styles["projects-table"]}>
                        <Table tableItems={projectTableItems} />
                    </div>
                    :
                    <LoadingSpinner />
            }
        </div>
    )
}

export default ProjectPageComponent