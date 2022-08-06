import styles from "../../styles/projects/ProjectsPageComponent.module.css";
import ControlledStateHandler from "../../types/ControlledStateHandler";
import Project from "../../types/domain/Project";
import PrimaryButton from "../utils/buttons/PrimaryButton";
import ErrorMessage from "../utils/ErrorMessage";
import PlusIcon from "../utils/icons/PlusIcon";
import LoadingSpinner from "../utils/loading/LoadingSpinner";
import PageContainer from "../utils/PageContainer";
import Table, { TableItem } from "../utils/Table";
import WhiteTopBar from "../utils/WhiteTopBar";
import NewProjectModal from "./NewProjectModal";

export interface ProjectsPageComponentProps {
    newProjectNameStateHandler: ControlledStateHandler<string>;
    newProjectDescriptionHandler: ControlledStateHandler<string>;
    userProjects: Project[];
    onCreateNewProject: () => void;
    errorMessage?: string;
    showNewProjectModal: boolean;
    onNewProjectModalOpen: () => void;
    onNewProjectModalClose: () => void;
    onProjectClick: (project: Project) => void;
}

const ProjectsPageComponent = ({
    newProjectNameStateHandler,
    newProjectDescriptionHandler,
    userProjects,
    onCreateNewProject,
    errorMessage,
    showNewProjectModal,
    onNewProjectModalOpen,
    onNewProjectModalClose,
    onProjectClick }: ProjectsPageComponentProps) => {

    const projectTableItems: TableItem[] = userProjects.map(project => ({
        content: {
            Project: project.title,
            "Time Status": "7h"
        },
        onClick: () => onProjectClick(project)
    }))

    const displayedNewProjectModal = showNewProjectModal ? <NewProjectModal
        nameStateHandler={newProjectNameStateHandler}
        descriptionStateHandler={newProjectDescriptionHandler}
        onClose={onNewProjectModalClose}
        onSubmit={onCreateNewProject} /> : <></>

    return (
        <PageContainer>
            <>
                {displayedNewProjectModal}
                <WhiteTopBar>
                    <>
                        <h2>Projects</h2>
                        <span className={styles["new-project-button-container"]}>
                            <PrimaryButton onClick={onNewProjectModalOpen}>
                                <>
                                    <PlusIcon />
                                    <span className={styles["new-project-button__text"]}>New Project</span>
                                </>
                            </PrimaryButton>
                        </span>
                    </>
                </WhiteTopBar>
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
            </>
        </PageContainer>
    )
}

export default ProjectsPageComponent