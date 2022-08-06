import { useRouter } from 'next/router'
import React, { useEffect, useState } from 'react'
import { withDefaultLayout } from '../../components/layouts/DefaultLayout';
import BlackLoadingSpinner from '../../components/utils/loading/BlackLoadingSpinner';
import LoadingSpinner from '../../components/utils/loading/LoadingSpinner';
import { useAuthContext } from '../../context/AuthContext';
import withAuthentication from '../../higherOrderComponents/WithAuthentication';
import UseSingleProjectHandler from '../../hooks/UseSingleProjectHandler';

const SingleProject = () => {
  const router = useRouter();
  const authContext = useAuthContext();
  const { projectId } = router.query;

  const { project, loadProject, error } = UseSingleProjectHandler();

  useEffect(() => {
    if (!projectId) return;

    const accessToken = authContext.getAccessToken();
    loadProject(+projectId, accessToken);
  }, [authContext, projectId, loadProject]);

  if (!projectId) return <BlackLoadingSpinner />

  if (!project) return <div>
    <LoadingSpinner />
  </div>

  return (
    <div>
      <p>{project.title}</p>
      <p>{project.description}</p>
    </div>
  )
}

export default withAuthentication(withDefaultLayout(SingleProject))